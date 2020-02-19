using Andreys.Services;

namespace Andreys.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }
        [HttpGet("/")]
        public HttpResponse IndexSlash()
        {
            return this.Index();
        }
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var allProducts = productsService.GetAll();
                return this.View(allProducts,"Home");
            }

            return this.View();
        }
    }
}
