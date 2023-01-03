using Microsoft.AspNetCore.Mvc;
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
            HomeController controller = new HomeController();

            //act
            ViewResult result = controller.About() as ViewResult;
            //assert
            Assert.IsNotNull(result.Model);
        }
    }
}