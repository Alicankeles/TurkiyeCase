
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
    public class BolgesController : Controller
    {
        private TurkiyeEntities db = new TurkiyeEntities();

        // GET: Bolges
        public ActionResult Index()
        {
            return View(db.Bolges.ToList());
        }

        // GET: Bolges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolge bolge = db.Bolges.Find(id);
            if (bolge == null)
            {
                return HttpNotFound();
            }
            return View(bolge);
        }

        // GET: Bolges/Create
        public ActionResult Create()
        {
            return View();
        }


        
        // POST: Bolges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BolgeId,BolgeAdi")] Bolge bolge)
        {

            if (db.Bolges.Select(x => x.BolgeAdi).Count() >= 8)
            {
                throw new Exception("Daha Fazla Bolge Ekleyemezsiniz...");
            }
            else
            {

                if (db.Bolges.Any(c => c.BolgeAdi == bolge.BolgeAdi))
                {
                    throw new Exception("Aynı Bolge Adından tekrar giremezsiniz...");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        db.Bolges.Add(bolge);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    return View(bolge);
                }

            }

        }

        // GET: Bolges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolge bolge = db.Bolges.Find(id);
            if (bolge == null)
            {
                return HttpNotFound();
            }
            return View(bolge);
        }

        // POST: Bolges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BolgeId,BolgeAdi")] Bolge bolge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bolge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bolge);
        }

        // GET: Bolges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolge bolge = db.Bolges.Find(id);
            if (bolge == null)
            {
                return HttpNotFound();
            }
            return View(bolge);
        }

        // POST: Bolges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bolge bolge = db.Bolges.Find(id);
            db.Bolges.Remove(bolge);
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
