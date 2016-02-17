using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Artifact_Express.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //redirect user to the proper page based on his/her credentials
            if(User.IsInRole("Curator"))
            {
                @TempData["CurrentRole"] = "Curator";
                return RedirectToAction("Curator");
            }
            else if (User.IsInRole("Archivist"))
            {
                @TempData["CurrentRole"] = "Archivist";
                return RedirectToAction("Archivist");
            }
            else if (User.IsInRole("Conservator"))
            {
                @TempData["CurrentRole"] = "Conservator";
                return RedirectToAction("Conservator");
            }
            else if (User.IsInRole("TourGuide"))
            {
                @TempData["CurrentRole"] = "Tour Guide";
                return RedirectToAction("TourGuide");
            }
            else
                return View();
        }
        #region
        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
        #endregion


        [Authorize(Roles="Curator")]
        public ActionResult Curator()
        {
            return View();
        }


        [Authorize(Roles = "Archivist")]
        public ActionResult Archivist()
        {
            return View();
        }


        [Authorize(Roles = "Conservator")]
        public ActionResult Conservator()
        {
            return View();
        }


        [Authorize(Roles = "TourGuide")]
        public ActionResult TourGuide()
        {
            return View();
        }
    }
}