using Microsoft.AspNet.Identity;
using PlayDate.Models;
using PlayDate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayDate.WebMVC.Controllers
{
    [Authorize]
    public class ParkController : Controller
    {
        // GET: Park
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ParkService(userId);
            var model = service.GetParks();

            return View(model);
        }

        //GET: Create Park
        public ActionResult Create()
        {
            return View();
        }

        //GET: Crate POST Park
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ParkCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateParkService();

            if (service.CreatePark(model))
            {
                TempData["SaveResult"] = "Your Park was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Park could not be created.");

            return View(model);
        }

        private ParkService CreateParkService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ParkService(userId);
            return service;
        }
    }
}