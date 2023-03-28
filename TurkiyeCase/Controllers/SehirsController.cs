using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TurkiyeCase;

namespace TurkiyeCase.Controllers
{
    public class SehirsController : Controller
    {
        private TurkiyeEntities db = new TurkiyeEntities();

        // GET: Sehirs
        public ActionResult Index()
        {
            var sehirs = db.Sehirs.Include(s => s.Bolge);
            return View(sehirs.ToList());
        }

        // GET: Sehirs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sehir sehir = db.Sehirs.Find(id);
            if (sehir == null)
            {
                return HttpNotFound();
            }
            return View(sehir);
        }

        // GET: Sehirs/Create
        public ActionResult Create()
        {
            ViewBag.BolgeId = new SelectList(db.Bolges, "BolgeId", "BolgeAdi");
            return View();
        }

        // POST: Sehirs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SehirId,SehirAdi,BolgeId")] Sehir sehir)
        {
            if (db.Sehirs.Any(c => c.SehirAdi == sehir.SehirAdi))
            {
                throw new Exception("Aynı Şehir Adından tekrar giremezsiniz...");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Sehirs.Add(sehir);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.BolgeId = new SelectList(db.Bolges, "BolgeId", "BolgeAdi", sehir.BolgeId);
                return View(sehir);
            }
            
        }

        // GET: Sehirs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sehir sehir = db.Sehirs.Find(id);
            if (sehir == null)
            {
                return HttpNotFound();
            }
            ViewBag.BolgeId = new SelectList(db.Bolges, "BolgeId", "BolgeAdi", sehir.BolgeId);
            return View(sehir);
        }

        // POST: Sehirs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SehirId,SehirAdi,BolgeId")] Sehir sehir)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sehir).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BolgeId = new SelectList(db.Bolges, "BolgeId", "BolgeAdi", sehir.BolgeId);
            return View(sehir);
        }

        // GET: Sehirs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sehir sehir = db.Sehirs.Find(id);
            if (sehir == null)
            {
                return HttpNotFound();
            }
            return View(sehir);
        }

        // POST: Sehirs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sehir sehir = db.Sehirs.Find(id);
            db.Sehirs.Remove(sehir);
            db.SaveChanges();
            return RedirectToAction("Index");
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
