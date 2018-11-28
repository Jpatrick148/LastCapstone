using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneFinal.Models;


namespace CapstoneFinal.Controllers
{
    public class HomeController : Controller
    {
        private ViewController api = new ViewController();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            

            return View();
        }

        public ActionResult Result(string Make, string Model, string Year, string Color)
        {
            List<Car> a = api.GetCars(Make,Model,int.Parse(Year),Color);

            return View(a);
        }
    }
}
