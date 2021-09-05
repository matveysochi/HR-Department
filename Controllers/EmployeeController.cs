using Microsoft.AspNetCore.Mvc;
using HRD.Models;

namespace HRD.Controllers
{
    public class EmployeeController : Controller
    {
        readonly IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository repository) => employeeRepository = repository;
        public IActionResult Index() => View(employeeRepository.Employees);
        public IActionResult Create() => View("Edit", new Employee());
        public IActionResult Edit(long id) => View(employeeRepository.GetEmployee(id));

        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if(employee.Id == 0)
                {
                    employeeRepository.AddEmployee(employee);
                }
                else
                {
                    employeeRepository.UpdateEmployee(employee);
                }
                return RedirectToAction(nameof(Index));
            }
            return View("Edit", employee);
        }
    }
}