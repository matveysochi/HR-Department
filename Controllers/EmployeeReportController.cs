using System;
using Microsoft.AspNetCore.Mvc;
using HRD.Models;

namespace HRD.Controllers
{
    public class EmployeeReportController : Controller
    {
        readonly IReports reports;
        readonly IDivisionRepository divisionRepository;
        public EmployeeReportController(
            IReports reports,
            IDivisionRepository divisionRepository
            )
        {
            this.reports = reports;
            this.divisionRepository = divisionRepository;
        }
        public IActionResult Index(long? divisionId, DateTime? startDate, DateTime? endDate)
        {
            startDate ??= DateTime.Now;
            endDate ??= DateTime.Now;

            ViewBag.DivisionId = divisionId;
            ViewBag.StartDate = startDate.Value.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate.Value.ToString("yyyy-MM-dd");
            ViewBag.Divisions = divisionRepository.Divisions;

            var employees = reports.GetEmployees(divisionId, startDate.Value, endDate.Value);
            return View(employees);
        }
    }
}