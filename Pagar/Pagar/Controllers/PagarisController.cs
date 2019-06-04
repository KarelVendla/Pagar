using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pagar.Models;

namespace Pagar.Controllers
{
    public class PagarisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pagaris
        public ActionResult Index()
        {
            return View(db.Pagaris.Where(m => m.Valmis == false).ToList());
        }

        public ActionResult Valmis_Tooted()
        {
            return View(db.Pagaris.Where(m => m.Valmis == true).ToList());
        }

        public ActionResult M_Valmis(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagari pagari = db.Pagaris.Find(id);
            if (pagari == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                pagari.Valmis = true;

                db.Pagaris.Add(pagari);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Pagaris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagari pagari = db.Pagaris.Find(id);
            if (pagari == null)
            {
                return HttpNotFound();
            }
            return View(pagari);
        }

        // GET: Pagaris/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pagaris/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Kogus,Toode,Tähtaeg,Lisa,TuleJärgi,Aadress")] Pagari pagari)
        {
            if (ModelState.IsValid)
            {
                db.Pagaris.Add(pagari);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pagari);
        }

        // GET: Pagaris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagari pagari = db.Pagaris.Find(id);
            if (pagari == null)
            {
                return HttpNotFound();
            }
            return View(pagari);
        }

        // POST: Pagaris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Kogus,Toode,Tähtaeg,Lisa,TuleJärgi,Aadress")] Pagari pagari)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagari).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pagari);
        }

        // GET: Pagaris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagari pagari = db.Pagaris.Find(id);
            if (pagari == null)
            {
                return HttpNotFound();
            }
            return View(pagari);
        }

        // POST: Pagaris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pagari pagari = db.Pagaris.Find(id);
            db.Pagaris.Remove(pagari);
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
