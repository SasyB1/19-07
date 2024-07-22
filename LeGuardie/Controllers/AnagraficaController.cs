using Microsoft.AspNetCore.Mvc;
using LeGuardie.Interfaces;
using LeGuardie.Models.Dto;

namespace LeGuardie.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly IUserService _userService;

        public AnagraficaController(IUserService userService)
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
            try
            {
                _userService.RegisterUser(user);
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(user);
            }
        }
    }
}
