using System;
using System.Collections.Generic;

namespace HRD.Models
{
    public interface IReports
    {
        // Метод получения выборки данных для построения отчета по подразделениям в формате словаря
        // ключ:        Родительское подразделение
        // значение:    Перечисление подчиненных подразделений
        Dictionary<Division, IEnumerable<Division>> GetDivisions(DateTime date);
        // Метод получения выборки данных для построения отчета по сотрудникам в формате словаря
        // ключ:        Подразделение
        // значение:    Сотрудники
        Dictionary<Division, IEnumerable<Employee>> GetEmployees(long? divisionId, DateTime startDate, DateTime endDate);
    }
}