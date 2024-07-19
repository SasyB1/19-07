using Microsoft.AspNetCore.Mvc;
using LeGuardie.Services;
using LeGuardie.Models.Dto;

namespace LeGuardie.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly UserService _userService;

        public AnagraficaController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            List<AnagraficaDto> users = _userService.GetUsers();
            return View(users);
        }

        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser(AnagraficaDto user)
        {
            _userService.RegisterUser(user);
            return RedirectToAction("Index");
        }
    }
}
