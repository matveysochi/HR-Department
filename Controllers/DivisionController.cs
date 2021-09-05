using Microsoft.AspNetCore.Mvc;
using HRD.Models;

namespace HRD.Controllers
{
    public class DivisionController : Controller
    {
        readonly IDivisionRepository divisionRepository;
        public DivisionController(IDivisionRepository repository) => divisionRepository = repository;
        public IActionResult Index() => View(divisionRepository.Divisions);
        public IActionResult Create() => View("Edit", new Division());
        public IActionResult Edit(long id) => View(divisionRepository.GetDivision(id));

        [HttpPost]
        public IActionResult Update(Division division)
        {
            if (ModelState.IsValid)
            {
                if(division.Id == 0)
                {
                    divisionRepository.AddDivision(division);
                }
                else
                {
                    divisionRepository.UpdateDivision(division);
                }
                return RedirectToAction(nameof(Index));
            }
            return View("Edit", division);
        }
    }
}