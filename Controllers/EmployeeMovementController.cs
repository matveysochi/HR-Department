using System;
using Microsoft.AspNetCore.Mvc;
using HRD.Models;

namespace HRD.Controllers
{
    public class EmployeeMovementController : Controller
    {
        readonly IEmployeeMovementRepository employeeMovementRepository;
        readonly IDivisionRepository divisionRepository;
        readonly IEmployeeRepository employeeRepository;
        public EmployeeMovementController(
            IEmployeeMovementRepository employeeMovementRepository,
            IDivisionRepository divisionRepository,
            IEmployeeRepository employeeRepository
            )
        {
            this.employeeRepository = employeeRepository;
            this.employeeMovementRepository = employeeMovementRepository;
            this.divisionRepository = divisionRepository;
        }

        public IActionResult Index() => View(employeeMovementRepository.EmployeeMovements);
        public IActionResult Create()
        {
            PrepareBag();
            EmployeeMovement employeeMovement = new() { Date = DateTime.Now };
            return View("Edit", employeeMovement);
        }
        public IActionResult Edit(long id)
        {
            PrepareBag();
            return View(employeeMovementRepository.GetEmployeeMovement(id));
        }

        [HttpPost]
        public IActionResult Update(EmployeeMovement employeeMovement)
        {
            if (ModelState.IsValid)
            {
                if(employeeMovement.Id == 0)
                {
                    employeeMovementRepository.AddEmployeeMovement(employeeMovement);
                }
                else
                {
                    employeeMovementRepository.UpdateEmployeeMovement(employeeMovement);
                }
                return RedirectToAction(nameof(Index));
            }
            PrepareBag();
            return View("Edit", employeeMovement);
        }

        void PrepareBag()
        {
            ViewBag.MovementTypes = Enum.GetValues(typeof(EmployeeMovementTypes));
            ViewBag.Employees = employeeRepository.Employees;
            ViewBag.Divisions = divisionRepository.Divisions;
        }
    }
}