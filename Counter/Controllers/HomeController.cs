using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Counter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Counter";

            return View();
        }

        [HttpGet]
        public JsonResult Increment()
        {
            int count = Counter.Models.Counter.GetCount();
            string error = "";

            if (count < 10)
            {
                count++;
            }
            else
            {
                error = "You have reach the max value.";
            }
            Counter.Models.Counter.SaveCount(count);

            return Json(new { count = count, error = error }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Reset()
        {
            int count = 0;

            Counter.Models.Counter.SaveCount(count);

            return Json(new { count = count }, JsonRequestBehavior.AllowGet);
        }
    }
}