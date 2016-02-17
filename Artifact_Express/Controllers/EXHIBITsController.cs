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
    public class EXHIBITsController : Controller
    {
        private MuseumEntities db = new MuseumEntities();

        // GET: EXHIBITs
        public ActionResult Index()
        {
            var eXHIBITs = db.EXHIBITs.Include(e => e.COLLECTION).Include(e => e.LOCATION);
            return View(eXHIBITs.ToList());
        }

        // GET: EXHIBITs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EXHIBIT eXHIBIT = db.EXHIBITs.Find(id);
            if (eXHIBIT == null)
            {
                return HttpNotFound();
            }
            return View(eXHIBIT);
        }

        #region
        //// GET: EXHIBITs/Create
        //public ActionResult Create()
        //{
        //    ViewBag.CollectionInExhibit = new SelectList(db.COLLECTIONs, "CollectionID", "CollectionName");
        //    ViewBag.LocationInExhibit = new SelectList(db.LOCATIONs, "LocationId", "StorageOrDisplay");
        //    return View();
        //}

        //// POST: EXHIBITs/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ExhibitID,ExhibitName,ExhibitDescription,ExhibitBeginningDate,ExhibitEndingDate,CollectionInExhibit,LocationInExhibit")] EXHIBIT eXHIBIT)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.EXHIBITs.Add(eXHIBIT);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CollectionInExhibit = new SelectList(db.COLLECTIONs, "CollectionID", "CollectionName", eXHIBIT.CollectionInExhibit);
        //    ViewBag.LocationInExhibit = new SelectList(db.LOCATIONs, "LocationId", "StorageOrDisplay", eXHIBIT.LocationInExhibit);
        //    return View(eXHIBIT);
        //}

        //// GET: EXHIBITs/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    EXHIBIT eXHIBIT = db.EXHIBITs.Find(id);
        //    if (eXHIBIT == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CollectionInExhibit = new SelectList(db.COLLECTIONs, "CollectionID", "CollectionName", eXHIBIT.CollectionInExhibit);
        //    ViewBag.LocationInExhibit = new SelectList(db.LOCATIONs, "LocationId", "StorageOrDisplay", eXHIBIT.LocationInExhibit);
        //    return View(eXHIBIT);
        //}

        //// POST: EXHIBITs/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ExhibitID,ExhibitName,ExhibitDescription,ExhibitBeginningDate,ExhibitEndingDate,CollectionInExhibit,LocationInExhibit")] EXHIBIT eXHIBIT)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(eXHIBIT).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CollectionInExhibit = new SelectList(db.COLLECTIONs, "CollectionID", "CollectionName", eXHIBIT.CollectionInExhibit);
        //    ViewBag.LocationInExhibit = new SelectList(db.LOCATIONs, "LocationId", "StorageOrDisplay", eXHIBIT.LocationInExhibit);
        //    return View(eXHIBIT);
        //}

        //// GET: EXHIBITs/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    EXHIBIT eXHIBIT = db.EXHIBITs.Find(id);
        //    if (eXHIBIT == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(eXHIBIT);
        //}

        //// POST: EXHIBITs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    EXHIBIT eXHIBIT = db.EXHIBITs.Find(id);
        //    db.EXHIBITs.Remove(eXHIBIT);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        #endregion

        [HttpGet]
        public ActionResult getExhibitName()
        {
            return PartialView();
        }

        //Our stored procedure
        [HttpPost]
        public ActionResult getArtifactsInExhibition(string ExhibitionName)
        {
            var model = db.GetArtifactsInExhibition(ExhibitionName);
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
