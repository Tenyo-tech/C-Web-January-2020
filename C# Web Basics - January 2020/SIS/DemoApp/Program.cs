using SIS.HTTP;
using SIS.HTTP.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    public static class Program
    {
        public static async Task Main()
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();

            var routeTable = new List<Route>();
            routeTable.Add(new Route(HttpMethodType.Get, "/", Index));
            routeTable.Add(new Route(HttpMethodType.Post, "/Tweets/Create", CreateTweet));
            routeTable.Add(new Route(HttpMethodType.Get, "/favicon.ico", FavIcon));
            
            var httpServer = new HttpServer(80, routeTable);
            await httpServer.StartAsync();
        }

        // /headers => html table the list of all header

        private static HttpResponse FavIcon(HttpRequest request)
        {
            var byteContent = File.ReadAllBytes("wwwroot/favicon.ico");
            return new FileResponse(byteContent, "image/x-icon");
        }

        public static HttpResponse Index(HttpRequest request)
        {
            var username = request.SessionData.ContainsKey("Username") ? request.SessionData["Username"] : "Anonymous";

            var db = new ApplicationDbContext();
            var tweets = db.Tweets.Select(x => new
            {
                x.CreatedOn,
                x.Creator,
                x.Content
            }).ToList();
            StringBuilder html = new StringBuilder();
            html.Append("<table><tr><th><>");

            return new HtmlResponse($"<form action ='/Tweets/Create' method = 'post'><input name ='creator' /><br /><textarea name='tweetName'></textarea><br /><input type='submit' /></form>");
        }


        public static HttpResponse CreateTweet(HttpRequest request)
        {
            var db = new ApplicationDbContext();
            var entityEntry = db.Tweets.Add(new Tweet
            {
                CreatedOn = DateTime.UtcNow,
                Creator = request.FormData["creator"],
                Content = request.FormData["tweetName"]
            });
            db.SaveChanges();

            return  new RedirectResponse("/");
        }
    }
}
