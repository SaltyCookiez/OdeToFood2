using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    public class CuisineController : Controller
    {
        [HttpPost]
        public IActionResult Search(string name = "french")
        {
            return Content("Esimene:" + name);
        }

        [HttpGet]
        public IActionResult Search(string name, bool notused)
        {
            return Content("Search");
        }
    }
}