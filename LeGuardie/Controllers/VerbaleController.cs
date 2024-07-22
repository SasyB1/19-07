using LeGuardie.Interfaces;
using Microsoft.AspNetCore.Mvc;
using LeGuardie.Models.Dto;
using LeGuardie.Models;

namespace LeGuardie.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly IVerbaleService _verbaleService;

        public VerbaleController(IVerbaleService verbaleService)
        {
            _verbaleService = verbaleService;
        }
        public IActionResult Index()
        {
            List<VerbaleDto> verbals = _verbaleService.GetVerbals();
            return View(verbals);
        }

        public IActionResult NewVerbal()
        {   
            ViewBag.Utenti = _verbaleService.GetUsers();
            ViewBag.Violazioni = _verbaleService.GetViolations();
            return View();
        }

        [HttpPost]
        public IActionResult NewVerbal(VerbaleDto verbale)
        {
            _verbaleService.NewVerbal(verbale);
            return RedirectToAction("Index");
        }

        public IActionResult ListViolation()
            {
            List<Violazione> violations = _verbaleService.GetViolations();
            return View(violations);
        }
    }
}
