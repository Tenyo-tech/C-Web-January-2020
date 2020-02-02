using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SIS.HTTP;
using SulsApp.Controllers;

namespace SulsApp
{
    public static class Program
    {
        public static async Task Main()
        {

            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();

            var routeTable = new List<Route>();
            routeTable.Add(new Route(HttpMethodType.Get, "/", new HomeController().Index));
            routeTable.Add(new Route(HttpMethodType.Get, "/css/bootstrap.min.css", new StaticFilesController().Bootstrap));
            routeTable.Add(new Route(HttpMethodType.Get, "/css/reset.css", new StaticFilesController().Reset));
            routeTable.Add(new Route(HttpMethodType.Get, "/css/site.css", new StaticFilesController().Site));

            routeTable.Add(new Route(HttpMethodType.Get, "/Users/Login", new UsersController().Login));
            routeTable.Add(new Route(HttpMethodType.Get, "/Users/Register", new UsersController().Register));

            var httpServer = new HttpServer(80, routeTable);
            await httpServer.StartAsync();
        }
    }
}
