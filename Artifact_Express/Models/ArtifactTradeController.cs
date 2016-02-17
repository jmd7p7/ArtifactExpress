using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Artifact_Express.Models
{
    public class ArtifactTradeController : Controller
    {
        private MuseumEntities db = new MuseumEntities();


        // GET: ArtifactTrade
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult getMusuemNameForBorrowedArtifacts()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ArtifactsBorrowed(string museumName)
        {
            var model = db.ArtifactsBorrowed(museumName);
            return View(model);
        }


        [HttpGet]
        public ActionResult getMusuemNameForLoanedArtifacts()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ArtifactsOnLoan(string museumName)
        {
            var model = db.ArtifactsOnLoan(museumName);
            return View(model);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}