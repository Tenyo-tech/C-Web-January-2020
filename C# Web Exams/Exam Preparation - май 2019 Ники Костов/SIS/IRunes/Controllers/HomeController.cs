using IRunes.Services;
using IRunes.ViewModels.Home;
using SIS.HTTP;
using SIS.MvcFramework;

namespace IRunes.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersService usersService;

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var viewmodel = new HomeViewModel();
                viewmodel.Username = this.usersService.GetUsername(this.User);
                return this.View(viewmodel,"Home");
            }

            return this.View();
        }


        [HttpGet("/Home/Index")]
        public HttpResponse IndexFullPage()
        {
            return this.Index();
        }
    }
}
