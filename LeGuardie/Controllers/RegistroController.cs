using Microsoft.AspNetCore.Mvc;
using LeGuardie.Interfaces;
using LeGuardie.Models.Dto;

namespace LeGuardie.Controllers
{
    public class RegistroController : Controller
    {
        private readonly IRegistroService _registroService;

        public RegistroController(IRegistroService registroService)
            {
            _registroService = registroService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VerbalsForUser()
        {
            List<VerbaleDto> verbali = _registroService.GetVerbalsForUsers();
            return View(verbali);
        }

        public IActionResult GetTotalPointsLost()
            {
            List<VerbaleDto> verbali = _registroService.GetTotalPointsLost();
            return View(verbali);
        }

        public IActionResult Greater10Points()
            {
            List<VerbaleDto> verbali = _registroService.Greater10Points();
            return View(verbali);
        }

        public IActionResult Verbals400()
             {
            List<VerbaleDto> verbali = _registroService.GetVerbals400();
            return View(verbali);
        }
    }
}
