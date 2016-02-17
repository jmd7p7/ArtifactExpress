using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Artifact_Express;

namespace Artifact_Express.Controllers
{
    public class CollectionController : Controller
    {
        private MuseumEntities db = new MuseumEntities();

        // GET: Collection
        public ActionResult Index()
        {
            var cOLLECTIONs = db.COLLECTIONs.Include(c => c.COUNTRY).Include(c => c.TIMEPERIOD);
            return View(cOLLECTIONs.ToList());
        }

        // GET: Collection/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLLECTION cOLLECTION = db.COLLECTIONs.Find(id);
            if (cOLLECTION == null)
            {
                return HttpNotFound();
            }
            return View(cOLLECTION);
        }

        [HttpGet]
        public ActionResult getCollectionName()
        {
            return PartialView();
        }

        //Our stored procedure

        [HttpPost]
        public ActionResult getSpecificCollection(string collectionName)
        {
            var model = db.getSpecificCollection(collectionName);
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
