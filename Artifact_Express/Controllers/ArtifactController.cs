using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Artifact_Express;
using Artifact_Express.Models;

namespace Artifact_Express.Controllers
{
    [Authorize(Roles="Curator, Archivist, Conservator, TourGuide")]
    public class ArtifactController : Controller
    {
        private MuseumEntities db = new MuseumEntities();

        // GET: Artifact
        public ActionResult Index()
        {
            var aRTIFACTs = db.ARTIFACTs.Include(a => a.ARTIFACTTYPE1).Include(a => a.COUNTRY).Include(a => a.TIMEPERIOD);
            return View(aRTIFACTs.ToList());
        }

        // GET: Artifact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTIFACT aRTIFACT = db.ARTIFACTs.Find(id);
            if (aRTIFACT == null)
            {
                return HttpNotFound();
            }
            return View(aRTIFACT);
        }

        // GET: Artifact/Create
        public ActionResult Create()
        {
            ViewBag.ArtifactType = new SelectList(db.ARTIFACTTYPEs, "ArtifactTypeId", "Type");
            ViewBag.CountryOfOrigin = new SelectList(db.COUNTRies, "CountryID", "CountryName");
            ViewBag.OfTimePeriod = new SelectList(db.TIMEPERIODs, "TimePeriodId", "TimePeriodName");
            return View();
        }

        // POST: Artifact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtifactId,ArtifactName,ArtifactDescriptionSummary,AppraisedValue,InsuredValue,OfTimePeriod,ArtifactType,CountryOfOrigin")] ARTIFACT aRTIFACT)
        {
            if (ModelState.IsValid)
            {
                db.ARTIFACTs.Add(aRTIFACT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtifactType = new SelectList(db.ARTIFACTTYPEs, "ArtifactTypeId", "Type", aRTIFACT.ArtifactType);
            ViewBag.CountryOfOrigin = new SelectList(db.COUNTRies, "CountryID", "CountryName", aRTIFACT.CountryOfOrigin);
            ViewBag.OfTimePeriod = new SelectList(db.TIMEPERIODs, "TimePeriodId", "TimePeriodName", aRTIFACT.OfTimePeriod);
            return View(aRTIFACT);
        }

        // GET: Artifact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTIFACT aRTIFACT = db.ARTIFACTs.Find(id);
            if (aRTIFACT == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtifactType = new SelectList(db.ARTIFACTTYPEs, "ArtifactTypeId", "Type", aRTIFACT.ArtifactType);
            ViewBag.CountryOfOrigin = new SelectList(db.COUNTRies, "CountryID", "CountryName", aRTIFACT.CountryOfOrigin);
            ViewBag.OfTimePeriod = new SelectList(db.TIMEPERIODs, "TimePeriodId", "TimePeriodName", aRTIFACT.OfTimePeriod);
            return View(aRTIFACT);
        }

        // POST: Artifact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtifactId,ArtifactName,ArtifactDescriptionSummary,AppraisedValue,InsuredValue,OfTimePeriod,ArtifactType,CountryOfOrigin")] ARTIFACT aRTIFACT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aRTIFACT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtifactType = new SelectList(db.ARTIFACTTYPEs, "ArtifactTypeId", "Type", aRTIFACT.ArtifactType);
            ViewBag.CountryOfOrigin = new SelectList(db.COUNTRies, "CountryID", "CountryName", aRTIFACT.CountryOfOrigin);
            ViewBag.OfTimePeriod = new SelectList(db.TIMEPERIODs, "TimePeriodId", "TimePeriodName", aRTIFACT.OfTimePeriod);
            return View(aRTIFACT);
        }

        // GET: Artifact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTIFACT aRTIFACT = db.ARTIFACTs.Find(id);
            if (aRTIFACT == null)
            {
                return HttpNotFound();
            }
            return View(aRTIFACT);
        }

        // POST: Artifact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ARTIFACT aRTIFACT = db.ARTIFACTs.Find(id);
            db.ARTIFACTs.Remove(aRTIFACT);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Entry of some of our stored procedures
        [HttpGet]
        public ActionResult getAppraisedValueGreaterThan()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AppraisedValueGreaterThan(int appraisedNum)
        {
            ViewBag.Message = appraisedNum;
            var model = db.AppraisedValueGreaterThan(appraisedNum);
            return PartialView(model);
        }


        [HttpGet]
        public ActionResult getTimePeriod()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ArtifactsFromTimePeriod(string timePeriod)
        {
            var model = db.ArtifactsFromTimePeriod(timePeriod);
            return View(model);
        }

        [HttpGet]
        public ActionResult getArtifactForLocation()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult findArtifactLocation(string artifactName)
        {
            var model = db.FindArtifactLocation(artifactName).Single();
            return View(model);
        }

        [HttpGet]
        public ActionResult getArtifactForDescription()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ViewArtifactDescription(string artifactName)
        {
            var model = db.ViewArtifactDescription(artifactName).Single();
            return View(model);
        }


        [HttpGet]
        public ActionResult getLocation()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult GetArtifactsInLocation(int Room, int Floor)
        {
            TempData["Room"] = Room;
            TempData["Floor"] = Floor;
            var model = db.GetArtifactsInLocation(Room, Floor).ToList().AsEnumerable();
            List<ArtifactInLocation> AIL = new List<ArtifactInLocation>();
            foreach(string str in model)
            {
                AIL.Add(new ArtifactInLocation() { Artifact = str});
            }
            return View(AIL.AsEnumerable());
        }

        [HttpGet]
        public ActionResult getMusuemBorrowedFrom ()
        {
            return View();
        }

        [HttpPost] 
        public ActionResult ArtifactsBorrowed(string museumName)
        {
            var model = db.ArtifactsBorrowed(museumName);
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
