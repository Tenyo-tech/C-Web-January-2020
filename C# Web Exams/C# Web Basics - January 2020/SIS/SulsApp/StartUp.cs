using System;
using System.Collections.Generic;
using SIS.HTTP;
using SIS.MvcFramework;
using SulsApp.Controllers;

namespace SulsApp
{
    public class StartUp : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {

            routeTable.Add(new Route(HttpMethodType.Get, "/", new HomeController().Index));
            routeTable.Add(new Route(HttpMethodType.Get, "/css/bootstrap.min.css", new StaticFilesController().Bootstrap));
            routeTable.Add(new Route(HttpMethodType.Get, "/css/reset.css", new StaticFilesController().Reset));
            routeTable.Add(new Route(HttpMethodType.Get, "/css/site.css", new StaticFilesController().Site));
            routeTable.Add(new Route(HttpMethodType.Get, "/Users/Login", new UsersController().Login));
            routeTable.Add(new Route(HttpMethodType.Get, "/Users/Register", new UsersController().Register));
        }

        public void ConfigureServices()
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();
        }
    }
}
