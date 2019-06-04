using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
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

        //Loob vaate Statistika ning kuvab nummerdatud andmeid
        public ActionResult Statistika()
        {

            TempData["Kõik"] = db.Pagaris.Count();
            TempData["Lõpetatud"] = db.Pagaris.Where(m => m.Valmis == true).Count();
            TempData["Üleantud"] = db.Pagaris.Where(m => m.TuleJärgi == true).Count();
            return View();
        }
        //Loob diagrammi tellimuste, kohale toimetatute ja lõpetatud tellimuste kohta.
        public ActionResult chart()
        {
            var tellimused = db.Pagaris.Count();
            var lopetatud = db.Pagaris.Where(m => m.Valmis == true).Count();
            var uleantud = db.Pagaris.Where(m => m.TuleJärgi == true).Count();

            new Chart(width: 600, height: 300)
                .AddSeries(
                chartType: "doughnut",
                xValue: new[] { "Tellimusi", "Kohale toimetatud" ,"Valmistatud tooteid" },
                yValues: new[] { tellimused, uleantud ,lopetatud })
                .Write("png");
            return null;
        }

        // Loob vaate Valmis tooted, kus kuvatakse valmis tooted
        [Authorize]
        public ActionResult Valmis_Tooted()
        {
            return View(db.Pagaris.Where(m => m.Valmis == true).ToList());
        }

        //Meetod, mis võimaldab muuta toote üleantuks
        public ActionResult Antud(int? id)
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
                pagari.TuleJärgi = true;

                db.Entry(pagari).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Valmis_Tooted");
        }

        //Meetod, mis võimaldab määrata toode valmis tehtuks
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

                db.Entry(pagari).State = EntityState.Modified;
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
