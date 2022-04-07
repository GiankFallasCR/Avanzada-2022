using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectAvanzada.Models;

namespace ProyectAvanzada.Views
{
    public class SalarioController : Controller
    {
        private PrograAvanzadaProyectoEntities db = new PrograAvanzadaProyectoEntities();

        // GET: Salario
        [Authorize]
        public ActionResult Index()
        {
            return View(db.SALARIO.ToList());
        }

        // GET: Salario/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALARIO sALARIO = db.SALARIO.Find(id);
            if (sALARIO == null)
            {
                return HttpNotFound();
            }
            return View(sALARIO);
        }

        // GET: Salario/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "IDSALARIO,SALARIO1")] SALARIO sALARIO)
        {
            if (ModelState.IsValid)
            {
                db.SALARIO.Add(sALARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sALARIO);
        }

        // GET: Salario/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALARIO sALARIO = db.SALARIO.Find(id);
            if (sALARIO == null)
            {
                return HttpNotFound();
            }
            return View(sALARIO);
        }

        // POST: Salario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "IDSALARIO,SALARIO1")] SALARIO sALARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sALARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sALARIO);
        }

        // GET: Salario/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALARIO sALARIO = db.SALARIO.Find(id);
            if (sALARIO == null)
            {
                return HttpNotFound();
            }
            return View(sALARIO);
        }

        // POST: Salario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            SALARIO sALARIO = db.SALARIO.Find(id);
            db.SALARIO.Remove(sALARIO);
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
