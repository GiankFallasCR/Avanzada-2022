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
    public class VendedorController : Controller
    {
        private PrograAvanzadaProyectoEntities db = new PrograAvanzadaProyectoEntities();

        // GET: Vendedor
        [Authorize]
        public ActionResult Index()
        {
            var vENDEDOR = db.VENDEDOR.Include(v => v.CATEGORIA_VENDEDOR);
            return View(vENDEDOR.ToList());
        }

        // GET: Vendedor/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENDEDOR vENDEDOR = db.VENDEDOR.Find(id);
            if (vENDEDOR == null)
            {
                return HttpNotFound();
            }
            return View(vENDEDOR);
        }

        // GET: Vendedor/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.IDCATEGORIA = new SelectList(db.CATEGORIA_VENDEDOR, "IDCATEGORIA", "IDCATEGORIA");
            return View();
        }

        // POST: Vendedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "IDVENDEDOR,IDCATEGORIA,DIRECCION,NOMBRE,EMAIL,TELEFONO,PASWORD")] VENDEDOR vENDEDOR)
        {
            if (ModelState.IsValid)
            {
                db.VENDEDOR.Add(vENDEDOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCATEGORIA = new SelectList(db.CATEGORIA_VENDEDOR, "IDCATEGORIA", "IDCATEGORIA", vENDEDOR.IDCATEGORIA);
            return View(vENDEDOR);
        }

        // GET: Vendedor/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENDEDOR vENDEDOR = db.VENDEDOR.Find(id);
            if (vENDEDOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCATEGORIA = new SelectList(db.CATEGORIA_VENDEDOR, "IDCATEGORIA", "IDCATEGORIA", vENDEDOR.IDCATEGORIA);
            return View(vENDEDOR);
        }

        // POST: Vendedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "IDVENDEDOR,IDCATEGORIA,DIRECCION,NOMBRE,EMAIL,TELEFONO,PASWORD")] VENDEDOR vENDEDOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vENDEDOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCATEGORIA = new SelectList(db.CATEGORIA_VENDEDOR, "IDCATEGORIA", "IDCATEGORIA", vENDEDOR.IDCATEGORIA);
            return View(vENDEDOR);
        }

        // GET: Vendedor/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENDEDOR vENDEDOR = db.VENDEDOR.Find(id);
            if (vENDEDOR == null)
            {
                return HttpNotFound();
            }
            return View(vENDEDOR);
        }

        // POST: Vendedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            VENDEDOR vENDEDOR = db.VENDEDOR.Find(id);
            db.VENDEDOR.Remove(vENDEDOR);
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
