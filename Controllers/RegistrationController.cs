using FranksKaffeehaus.Models;
using FranksKaffeehaus.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

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

        // GET: RegistrationController/Edit/5
        public ActionResult Update(int id)
        {
            var model = _registrationContext.Users.Find(id);
            return View(model);
        }

        // POST: RegistrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(RegistrationViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _registrationContext.Users.Update(user);
                    _registrationContext.SaveChanges();
                }
                return View("UpdateSuccessful", user);
            }
            catch
            {
                return View();
            }
        }

        // GET: Registration/Delete/5
        public ActionResult DeleteUser(int id)
        {
            var model = _registrationContext.Users.Find(id);
            return View(model);
        }

        // POST: Registration/Delete/5
        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var user = _registrationContext.Users.Find(id);
                _registrationContext.Users.Remove(user);
                _registrationContext.SaveChanges();
                return View("DeleteSuccessful", user);
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
