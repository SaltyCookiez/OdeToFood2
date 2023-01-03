using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using System.Xml.Linq;

namespace OdeToFood.Views.Shared.Components
{
    [ViewComponent(Name = "BestReview")]
    public class BestReview : ViewComponent
    {
        private List<RestaurantReview> _reviews;
        public BestReview()
        {
            //_reviews = Controllers.RestaurantReviewsController._reviews;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var best = _reviews.OrderByDescending(r => r.Rating).First();
            return View("_bestReview", best);
        }
    }
}
