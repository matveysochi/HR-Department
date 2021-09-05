using System;
using Microsoft.AspNetCore.Mvc;
using HRD.Models;

namespace HRD.Controllers
{
    public class DivisionReportController : Controller
    {
        readonly IReports reports;
        public DivisionReportController(IReports reports) => this.reports = reports;
        public IActionResult Index(DateTime? date)
        {
            date ??= DateTime.Now;
            ViewBag.Date = date.Value.ToString("yyyy-MM-dd");
            return View(reports.GetDivisions(date.Value));
        }
    }
}