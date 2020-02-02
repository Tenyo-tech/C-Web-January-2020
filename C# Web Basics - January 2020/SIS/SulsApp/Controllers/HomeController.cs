using System.IO;
using SIS.HTTP;
using SIS.HTTP.Response;
using SIS.MvcFramework;

namespace SulsApp.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index(HttpRequest request)
        {
            return this.View();
        }
    }
}
