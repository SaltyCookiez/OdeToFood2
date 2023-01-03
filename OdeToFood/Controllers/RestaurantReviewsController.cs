//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using OdeToFood.Data;
//using OdeToFood.Models;

//namespace OdeToFood.Controllers
//{
//    public class RestaurantReviewsController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public RestaurantReviewsController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: RestaurantReviews
//        public async Task<IActionResult> Index()
//        {
//              return View(await _context.RestaurantReview.ToListAsync());
//        }

//        // GET: RestaurantReviews/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.RestaurantReview == null)
//            {
//                return NotFound();
//            }

//            var restaurantReview = await _context.RestaurantReview
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (restaurantReview == null)
//            {
//                return NotFound();
//            }

//            return View(restaurantReview);
//        }

//        // GET: RestaurantReviews/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: RestaurantReviews/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Name,City,Country,Rating")] RestaurantReview restaurantReview)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(restaurantReview);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(restaurantReview);
//        }

//        // GET: RestaurantReviews/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.RestaurantReview == null)
//            {
//                return NotFound();
//            }

//            var restaurantReview = await _context.RestaurantReview.FindAsync(id);
//            if (restaurantReview == null)
//            {
//                return NotFound();
//            }
//            return View(restaurantReview);
//        }

//        // POST: RestaurantReviews/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,City,Country,Rating")] RestaurantReview restaurantReview)
//        {
//            if (id != restaurantReview.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(restaurantReview);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!RestaurantReviewExists(restaurantReview.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(restaurantReview);
//        }

//        // GET: RestaurantReviews/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.RestaurantReview == null)
//            {
//                return NotFound();
//            }

//            var restaurantReview = await _context.RestaurantReview
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (restaurantReview == null)
//            {
//                return NotFound();
//            }

//            return View(restaurantReview);
//        }

//        // POST: RestaurantReviews/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.RestaurantReview == null)
//            {
//                return Problem("Entity set 'ApplicationDbContext.RestaurantReview'  is null.");
//            }
//            var restaurantReview = await _context.RestaurantReview.FindAsync(id);
//            if (restaurantReview != null)
//            {
//                _context.RestaurantReview.Remove(restaurantReview);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool RestaurantReviewExists(int id)
//        {
//          return _context.RestaurantReview.Any(e => e.Id == id);
//        }

//        public static List<RestaurantReview> _reviews = new List<RestaurantReview>
//        {
//            new RestaurantReview
//            {
//                Id = 1,
//                Name = "Cinnamon Club",
//                City = "London",
//                Country="UK",
//                Rating=10,
//            },
//            new RestaurantReview
//            {
//                Id = 2,
//                Name = "Marrakesh",
//                City = "D.C",
//                Country="USA",
//                Rating=10,
//            },
//            new RestaurantReview
//            {
//                Id = 3,
//                Name = "The House of Elliot",
//                City = "Ghent",
//                Country="Belgium",
//                Rating=10,
//            },
//        };
//    }
//}
