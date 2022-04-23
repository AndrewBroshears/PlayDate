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
    public class RatingController : Controller
    {
        // GET: Rating
        public ActionResult Index()
        {
            var service = CreateRatingService();
            var model = service.GetRatings();

            return View(model);
        }

        //GET: Create Rating
        public ActionResult Create()
        {
            var ctx = new ApplicationDbContext();
            ViewData["Park"] = ctx.Parks.Select(park => new SelectListItem
            {
                Text = park.ParkName,
                Value = park.ParkId.ToString()
            }).ToArray();

            /*ViewData["RatingStar"] = ctx.Ratings.Select(rating => new SelectListItem
            {
                Text = rating.RatingStar.ToString(),
                Value = rating.RatingStar.ToString()
            }).ToArray();*/

            return View();
        }

        //GET: Create POST Park
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RatingCreate model)
        {
            var ctx = new ApplicationDbContext();
            ViewData["Park"] = ctx.Parks.Select(park => new SelectListItem
            {
                Text = park.ParkName,
                Value = park.ParkId.ToString()
            }).ToArray();
            
            /*ViewData["RatingStar"] = ctx.Ratings.Select(rating => new SelectListItem
            {
                Text = rating.RatingStar.ToString(),
                Value = rating.RatingStar.ToString()
            }).ToArray();*/

            if (!ModelState.IsValid) return View(model);

            var service = CreateRatingService();

            if (service.CreateRating(model))
            {
                ViewData["SaveResult"] = "Your Rating was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Rating could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRatingService();
            var model = svc.GetRatingById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var ctx = new ApplicationDbContext();
            ViewData["Park"] = ctx.Parks.Select(park => new SelectListItem
            {
                Text = park.ParkName,
                Value = park.ParkId.ToString()
            }).ToArray();

            /*ViewData["RatingStar"] = ctx.Ratings.Select(rating => new SelectListItem
            {
                Text = rating.RatingStar.ToString(),
                Value = rating.RatingStar.ToString()
            }).ToArray();*/

            var service = CreateRatingService();
            var detail = service.GetRatingById(id);
            var model =
                new RatingEdit
                {
                    RatingId = detail.RatingId,
                    RatingStar = detail.RatingStar,
                    RatingComment = detail.RatingComment
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RatingEdit model)
        {
            var ctx = new ApplicationDbContext();
            ViewData["Park"] = ctx.Parks.Select(park => new SelectListItem
            {
                Text = park.ParkName,
                Value = park.ParkId.ToString()
            }).ToArray();

            /*ViewData["RatingStar"] = ctx.Ratings.Select(rating => new SelectListItem
            {
                Text = rating.RatingStar.ToString(),
                Value = rating.
            }).ToArray();*/

            if (!ModelState.IsValid) return View(model);

            if (model.RatingId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRatingService();

            if (service.UpdateRating(model))
            {
                ViewData["SaveResult"] = "Your Rating was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Rating could not be updated.");
            return View(model);
        }

        //Delete Delete Park
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRatingService();
            var model = svc.GetRatingById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRatingService();
            service.DeleteRating(id);
            ViewData["SaveResult"] = "Your Rating was deleted";

            return RedirectToAction("Index");
        }

        private RatingService CreateRatingService()
        {
            return new RatingService(User.Identity.GetUserId());
        }

        private ParkService CreateParkService()
        {
            return new ParkService(User.Identity.GetUserId());
        }
    }
}