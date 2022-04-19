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
    public class AmenityController : Controller
    {
        // GET: Amenity
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AmenityService(userId);
            var model = service.GetAmenities();

            return View(model);
        }

        //GET: Amernity Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Amenity Create
        [HttpPost]
        public ActionResult Create(AmenityCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAmenityService();

            if (service.CreateAmenity(model))
            {
                TempData["SaveResult"] = "Your Amenity was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Amenity could not be created.");

            return View(model);
        }

        //GET Amenity Edit
        public ActionResult Details(int id)
        {
            var svc = CreateAmenityService();
            var model = svc.GetAmenityById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAmenityService();
            var detail = service.GetAmenityById(id);
            var model =
                new AmenityEdit
                {
                    AmenityId = detail.AmenityId,
                    AmenityType = detail.AmenityType
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AmenityEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AmenityId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAmenityService();

            if (service.UpdateAmenity(model))
            {
                TempData["SaveResult"] = "Your Amenity was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Amenity could not be updated.");
            return View(model);
        }

        //Delete Delete Amenity
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAmenityService();
            var model = svc.GetAmenityById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAmenityService();
            service.DeleteAmenity(id);
            TempData["SaveResult"] = "Your Amenity was deleted";

            return RedirectToAction("Index");
        }

        private AmenityService CreateAmenityService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AmenityService(userId);
            return service;
        }

        private ParkService ParkService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ParkService(userId);
            return service;
        }
    }
}