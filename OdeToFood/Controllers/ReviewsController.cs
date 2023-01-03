﻿using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ReviewsController
        public ActionResult Index([Bind(Prefix = "id")] int restaurantId)
        {
            var model = _context.Restaurants
            .FirstOrDefault(r => r.Id == restaurantId);
            if (model == null)
            {
                return NotFound();
            }
            var reviewsmodel = _context.Reviews.Where(r => r.RestaurantId == restaurantId);
            if (reviewsmodel != null)
                model.Reviews = reviewsmodel.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create(int restaurantId)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _context.Reviews.Add(review);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), new { id = review.RestaurantId });
            }
            return View(review);
        }
    }
}
