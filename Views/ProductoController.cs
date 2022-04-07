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
    public class ProductoController : Controller
    {
        private PrograAvanzadaProyectoEntities db = new PrograAvanzadaProyectoEntities();

        // GET: Producto
        [Authorize]
        public ActionResult Index()
        {
            var pRODUCTO = db.PRODUCTO.Include(p => p.PROVEEDOR);
            return View(pRODUCTO.ToList());
        }

        // GET: Producto/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // GET: Producto/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.IDPROVEEDOR = new SelectList(db.PROVEEDOR, "IDPROVEEDOR", "NOMBRE");
            return View();
        }

        // POST: Producto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "IDPRODUCTO,IDPROVEEDOR,NOMBRE,PRECIO")] PRODUCTO pRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTO.Add(pRODUCTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDPROVEEDOR = new SelectList(db.PROVEEDOR, "IDPROVEEDOR", "NOMBRE", pRODUCTO.IDPROVEEDOR);
            return View(pRODUCTO);
        }

        // GET: Producto/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPROVEEDOR = new SelectList(db.PROVEEDOR, "IDPROVEEDOR", "NOMBRE", pRODUCTO.IDPROVEEDOR);
            return View(pRODUCTO);
        }

        // POST: Producto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "IDPRODUCTO,IDPROVEEDOR,NOMBRE,PRECIO")] PRODUCTO pRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPROVEEDOR = new SelectList(db.PROVEEDOR, "IDPROVEEDOR", "NOMBRE", pRODUCTO.IDPROVEEDOR);
            return View(pRODUCTO);
        }

        // GET: Producto/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            db.PRODUCTO.Remove(pRODUCTO);
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
