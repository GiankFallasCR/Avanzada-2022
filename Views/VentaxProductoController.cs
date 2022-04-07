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
    public class VentaxProductoController : Controller
    {

        private PrograAvanzadaProyectoEntities db = new PrograAvanzadaProyectoEntities();

        // GET: VentaxProducto
        [Authorize]
        public ActionResult Index()
        {
            var vENTAXPRODUCTO = db.VENTAXPRODUCTO.Include(v => v.PRODUCTO).Include(v => v.VENTA);
            return View(vENTAXPRODUCTO.ToList());
        }

        // GET: VentaxProducto/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTAXPRODUCTO vENTAXPRODUCTO = db.VENTAXPRODUCTO.Find(id);
            if (vENTAXPRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(vENTAXPRODUCTO);
        }

        // GET: VentaxProducto/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.IDPRODUCTO = new SelectList(db.VENTAXPRODUCTO, "IDPRODUCTO", "NOMBRE");
            ViewBag.IDVENTA = new SelectList(db.VENTA, "IDVENTA", "IDVENTA");
            return View();
        }

        // POST: VentaxProducto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "IDVENTA,IDPRODUCTO,CANTIDAD,DESCUENTO")] VENTAXPRODUCTO vENTAXPRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.VENTAXPRODUCTO.Add(vENTAXPRODUCTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDPRODUCTO = new SelectList(db.PRODUCTO, "IDPRODUCTO", "NOMBRE", vENTAXPRODUCTO.IDPRODUCTO);
            ViewBag.IDVENTA = new SelectList(db.VENTA, "IDVENTA", "IDVENTA", vENTAXPRODUCTO.IDVENTA);
            return View(vENTAXPRODUCTO);
        }

        // GET: VentaxProducto/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTAXPRODUCTO vENTAXPRODUCTO = db.VENTAXPRODUCTO.Find(id);
            if (vENTAXPRODUCTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPRODUCTO = new SelectList(db.PRODUCTO, "IDPRODUCTO", "NOMBRE", vENTAXPRODUCTO.IDPRODUCTO);
            ViewBag.IDVENTA = new SelectList(db.VENTA, "IDVENTA", "IDVENTA", vENTAXPRODUCTO.IDVENTA);
            return View(vENTAXPRODUCTO);
        }

        // POST: VentaxProducto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDVENTA,IDPRODUCTO,CANTIDAD,DESCUENTO")] VENTAXPRODUCTO vENTAXPRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vENTAXPRODUCTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPRODUCTO = new SelectList(db.PRODUCTO, "IDPRODUCTO", "NOMBRE", vENTAXPRODUCTO.IDPRODUCTO);
            ViewBag.IDVENTA = new SelectList(db.VENTA, "IDVENTA", "IDVENTA", vENTAXPRODUCTO.IDVENTA);
            return View(vENTAXPRODUCTO);
        }

        // GET: VentaxProducto/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTAXPRODUCTO vENTAXPRODUCTO = db.VENTAXPRODUCTO.Find(id);
            if (vENTAXPRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(vENTAXPRODUCTO);
        }

        // POST: VentaxProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            VENTAXPRODUCTO vENTAXPRODUCTO = db.VENTAXPRODUCTO.Find(id);
            db.VENTAXPRODUCTO.Remove(vENTAXPRODUCTO);
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
