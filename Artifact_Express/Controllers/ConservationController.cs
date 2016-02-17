using Artifact_Express.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Artifact_Express.Controllers
{
    public class ConservationController : Controller
    {

        private MuseumEntities db = new MuseumEntities();
        // GET: Conservation
        
        [HttpGet]
        public ActionResult getArtifactForStorageRequirements()
        {
            return PartialView();
        }


        //implementation of some of our stored procedures
        [HttpPost]
        public ActionResult getStorageRequirements(string ArtifactName)
        {
            var model = db.GetStorageRequirements(ArtifactName);
            return View(model);
        }


        [HttpGet]
        public ActionResult getArtifactForAuthentication()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult GetArtifactAuthentication (string artifactName)
        {
            var model = db.GetArtifactAuthentication(artifactName).Single();
            AuthenticationStatus AS = new AuthenticationStatus() { isAuthenticated = model.Authenticated, artifactName = model.ArtifactName };
            return View(AS);
        }
        
        [HttpGet]
        public ActionResult getArtifactForTest()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult GetAllToolsUsedInTest(string artifactName)
        {
            var model = db.GetAllToolsUsedInTest(artifactName);
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