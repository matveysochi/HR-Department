using System;
using System.Collections.Generic;
using System.Linq;

namespace HRD.Models
{
    public class EFReports : IReports
    {
        readonly AppDbContext dbContext;
        public EFReports(AppDbContext dbContext) => this.dbContext = dbContext;

        public Dictionary<Division, IEnumerable<Division>> GetDivisions(DateTime reportDate)
        {
            // Получаем срез последних состояний подразделений на дату отчета и выбираем не исключенные
            var divisions = 
                from move in dbContext.DivisionMovements
                where move.Date <= reportDate
                group move.Date by move.DivisionId
                into groupedData
                select new { DivisionId = groupedData.Key, Date = groupedData.Max() }
                into lastData
                join move in dbContext.DivisionMovements
                on lastData equals new { move.DivisionId, move.Date }
                where move.MovementType != DivisionMovementTypes.Исключить 
                select new { move.Division, move.ParentDivision };
            
            // Создаем фиктивное корневое родительское подразделение
            Division rootDivision = new() { Name = "Предприятие" };
            
            // Возращаем сгруппированные по родительскому подразделению подчиненные подразделения
            return
                (from division in divisions.AsEnumerable()
                 group division.Division by division.ParentDivision)
                 .ToDictionary(elem => elem.Key ?? rootDivision, elem => elem.AsEnumerable());
        }

        public Dictionary<Division, IEnumerable<Employee>> GetEmployees(long? divisionId, DateTime startDate, DateTime endDate)
        {
            // Получаем срез последних состояний сотрудников на начало периода и выбираем не уволенных
            var employeesAtTheBeginningOfThePeriod =
                from move in dbContext.EmployeeMovements
                where move.Date <= startDate
                group move.Date by move.EmployeeId
                into groupData
                select new { EmployeeId = groupData.Key, Date = groupData.Max() }
                into lastData
                join move in dbContext.EmployeeMovements
                on lastData equals new { move.EmployeeId, move.Date }
                where move.MovementType != EmployeeMovementTypes.Увольнение
                select new { move.Employee, move.Division };
            
            // Получаем нанятых и перемещенных в течение периода
            var employeesInThePeriod =
                from move in dbContext.EmployeeMovements
                where move.Date >= startDate && move.Date <= endDate && move.MovementType != EmployeeMovementTypes.Увольнение
                select new { move.Employee, move.Division };
            
            // Объединяем обе выборки и удаляем дубликаты
            var employees =
                employeesAtTheBeginningOfThePeriod
                .Union(employeesInThePeriod)
                .Distinct();
            
            // Фильтруем в случае необходимости по указанному подразделению
            if (divisionId.HasValue) employees = employees
                    .Where(record => record.Division.Id == divisionId);
            
            // Возращаем сгруппированных по родительскому подразделению сотрудников
            return
                (from employee in employees.AsEnumerable()
                group employee.Employee by employee.Division)
                .ToDictionary(elem => elem.Key, elem => elem.AsEnumerable());
        }
    }
}