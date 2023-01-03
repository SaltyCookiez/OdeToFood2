[assembly: HostingStartup(typeof(OdeToFood.Areas.Identity.IdentityHostingStartup))]
namespace OdeToFood.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}