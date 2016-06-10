using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Data;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private IWordRepository _repo;

        public HomeController(IWordRepository repo)
        {
            _repo = repo;
        }
        public ActionResult Index()
        {
            var words = _repo.GetWords()
                .Take(25)
                .ToList();


            return View(words);
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