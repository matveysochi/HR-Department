using System;
using Microsoft.AspNetCore.Mvc;
using HRD.Models;

namespace HRD.Controllers
{
    public class DivisionMovementController : Controller
    {
        readonly IDivisionMovementRepository divisionMovementRepository;
        readonly IDivisionRepository divisionRepository;

        public DivisionMovementController(
            IDivisionMovementRepository divisionMovementRepository,
            IDivisionRepository divisionRepository
            )
        {
            this.divisionRepository = divisionRepository;
            this.divisionMovementRepository = divisionMovementRepository;
        }

        public IActionResult Index() => View(divisionMovementRepository.DivisionMovements);
        public IActionResult Create()
        {
            PrepareBag();
            DivisionMovement divisionMovement = new() { Date = DateTime.Now };
            return View("Edit", divisionMovement);
        }
        public IActionResult Edit(long id)
        {
            PrepareBag();
            return View(divisionMovementRepository.GetDivisionMovement(id));
        }

        [HttpPost]
        public IActionResult Update(DivisionMovement divisionMovement)
        {
            if (ModelState.IsValid)
            {
                if(divisionMovement.Id == 0)
                {
                    divisionMovementRepository.AddDivisionMovement(divisionMovement);
                }
                else
                {
                    divisionMovementRepository.UpdateDivisionMovement(divisionMovement);
                }
                return RedirectToAction(nameof(Index));
            }
            PrepareBag();
            return View("Edit", divisionMovement);
        }

        void PrepareBag()
        {
            ViewBag.MovementTypes = Enum.GetValues(typeof(DivisionMovementTypes));
            ViewBag.Divisions = divisionRepository.Divisions;
        }
    }
}