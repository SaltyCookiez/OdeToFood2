using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OdeToFood.Controllers;

namespace OdeToFoodTests
{
    [TestClass]
    public class OdeToFoodTests
    {
        [TestMethod]
        public void About()
        {
            //Arrange
            using var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = logFactory.CreateLogger<HomeController>();
            HomeController controller = new HomeController(logger);

            //act
            ViewResult result = controller.About() as ViewResult;
            //assert
            Assert.IsNotNull(result.Model);
        }
    }
}