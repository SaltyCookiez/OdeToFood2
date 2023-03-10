using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;
using OdeToFood.Models;
using OdeToFood.Models.ViewModels;

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
        public ActionResult Create(int restaurantId, RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _context.Reviews.Add(review);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), new { id = review.RestaurantId });
            }
            return View(review);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _context.Reviews.Find(id);
            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(int id, ReviewViewModel review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var current = _context.Reviews.Find(id);
                current.Body = review.Body;
                current.Rating = review.Rating;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), new { id = current.RestaurantId });
            }
            return View(review);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Restaurants == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reviews == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Restaurants'  is null.");
            }
            var review = await _context.Reviews.FindAsync(id);
            int restaurantID = review.RestaurantId;
            if (review != null)
            {
                _context.Reviews.Remove(review);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = restaurantID });
        }
    }
}
