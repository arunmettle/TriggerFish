using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TriggerFish.Context;
using TriggerFish.Models;

namespace TriggerFish.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            NewsApiContext newsApiContext = new NewsApiContext();
            List<NewsArticle> newsArticles = newsApiContext.GetNewsFeed1();
            return View(newsArticles);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}