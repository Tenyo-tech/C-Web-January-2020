using SIS.MvcFramework;
using SIS.MvcFramework.Result;

namespace Panda.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
