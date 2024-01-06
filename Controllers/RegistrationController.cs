using FranksKaffeehaus.Models;
using FranksKaffeehaus.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FranksKaffeehaus.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly RegistrationContext _registrationContext;

        public RegistrationController(ILogger<RegistrationController> logger, RegistrationContext registrationContext)
        {
            _logger = logger;
            _registrationContext = registrationContext;
        }

        public IActionResult List()
        {
            var createModel = _registrationContext.Users.ToList();
            return View(createModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult RegistrationSuccessful(RegistrationViewModel newUser)
        {
            return View(newUser);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RegistrationViewModel newUser)
        {
            if (ModelState.IsValid)
            {
                _registrationContext.Users.Add(newUser);
                _registrationContext.SaveChanges();
            }
            return RedirectToAction("RegistrationSuccessful", newUser);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
