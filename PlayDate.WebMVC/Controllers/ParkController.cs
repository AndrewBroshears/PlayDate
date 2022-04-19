using Microsoft.AspNet.Identity;
using PlayDate.Data;
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
            var ctx = new ApplicationDbContext();
            ViewData["Amenity"] = ctx.Amenities.Select(amenity => new SelectListItem
            {
                Text = amenity.AmenityType,
                Value = amenity.AmenityId.ToString()
            }).ToArray();
            return View();
        }

        //GET: Create POST Park
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ParkCreate model)
        {
            var ctx = new ApplicationDbContext();
            ViewData["Amenity"] = ctx.Amenities.Select(amenity => new SelectListItem
            {
                Text = amenity.AmenityType,
                Value = amenity.AmenityId.ToString()
            }).ToArray();

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

        public ActionResult Details(int id)
        {
            var svc = CreateParkService();
            var model = svc.GetParkById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var ctx = new ApplicationDbContext();
            ViewData["Amenity"] = ctx.Amenities.Select(amenity => new SelectListItem
            {
                Text = amenity.AmenityType,
                Value = amenity.AmenityId.ToString()
            }).ToArray();

            var service = CreateParkService();
            var detail = service.GetParkById(id);
            var model =
                new ParkEdit
                {
                    ParkId = detail.ParkId,
                    ParkName = detail.ParkName,
                    ParkAddress = detail.ParkAddress
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ParkEdit model)
        {
            var service = CreateParkService();

            var ctx = new ApplicationDbContext();
            ViewData["Amenity"] = ctx.Amenities.Select(amenity => new SelectListItem
            {
                Text = amenity.AmenityType,
                Value = amenity.AmenityId.ToString()
            }).ToArray();

            if (service.UpdatePark(model))
            {
                TempData["SaveResult"] = "Your Park was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Park could not be updated.");
            return View(model);
        }

        //Delete Delete Park
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateParkService();
            var model = svc.GetParkById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateParkService();
            service.DeletePark(id);
            TempData["SaveResult"] = "Your Park was deleted";

            return RedirectToAction("Index");
        }

        private ParkService CreateParkService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ParkService(userId);
            return service;
        }

        private AmenityService CreateAmenityService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AmenityService(userId);
            return service;
        }
    }
}