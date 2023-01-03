﻿using AspNetCore.Unobtrusive.Ajax;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using OdeToFood.Models;
using System.Diagnostics;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public ActionResult Autocomplete(string term)
        {
            var model = _context.Restaurants
                .Where(r => r.Name.StartsWith(term))
                .Take(10)
                .Select(r => new
                {
                    label = r.Name
                });
            return Json(model);
        }

        public IActionResult Index(string? searchTerm = null)
        {
            var model = _context.Restaurants
            .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
            .Where(r => searchTerm == null || r.Name.Contains(searchTerm))
            .Take(10)
            .Select(r => new RestaurantListViewModel
            {
                Id = r.Id,
                Name = r.Name,
                City = r.City,
                Country = r.Country,
                CountOfReviews = r.Reviews.Count()
            });

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            var model = new AboutModel()
            {
                Name = "Moris Vider",
                Location = "Tallinn"
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}