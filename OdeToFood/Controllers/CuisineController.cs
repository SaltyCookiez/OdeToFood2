using Microsoft.AspNetCore.Mvc;
using OdeToFood.Filter;

namespace OdeToFood.Controllers
{
    [Log]
    public class CuisineController : Controller
    {
        public IActionResult Search(string name = "french")
        {
            throw new Exception("Something terrible happend! :O");

            //return Content("Esimene:" + name);
        }
    }
}