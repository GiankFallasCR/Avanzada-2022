using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectAvanzada.Models;

namespace ProyectAvanzada.Controllers
{
    public class InventarioController : Controller
    {
        private PrograAvanzadaProyectoEntities db = new PrograAvanzadaProyectoEntities();

        // GET: Inventario
        [Authorize]
        public ActionResult Index()
        {
            var iNVENTARIO = db.INVENTARIO.Include(i => i.PRODUCTO);
            return View(iNVENTARIO.ToList());
        }

        // GET: Inventario/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTARIO iNVENTARIO = db.INVENTARIO.Find(id);
            if (iNVENTARIO == null)
            {
                return HttpNotFound();
            }
            return View(iNVENTARIO);
        }

        // GET: Inventario/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.IDPRODUCTO = new SelectList(db.PRODUCTO, "IDPRODUCTO", "NOMBRE");
            return View();
        }

        // POST: Inventario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "IDINVENTARIO,IDPRODUCTO,CANTIDAD_COMPRADA,STOCK")] INVENTARIO iNVENTARIO)
        {
            if (ModelState.IsValid)
            {
                db.INVENTARIO.Add(iNVENTARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDPRODUCTO = new SelectList(db.PRODUCTO, "IDPRODUCTO", "NOMBRE", iNVENTARIO.IDPRODUCTO);
            return View(iNVENTARIO);
        }

        // GET: Inventario/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTARIO iNVENTARIO = db.INVENTARIO.Find(id);
            if (iNVENTARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPRODUCTO = new SelectList(db.PRODUCTO, "IDPRODUCTO", "NOMBRE", iNVENTARIO.IDPRODUCTO);
            return View(iNVENTARIO);
        }

        // POST: Inventario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "IDINVENTARIO,IDPRODUCTO,CANTIDAD_COMPRADA,STOCK")] INVENTARIO iNVENTARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNVENTARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPRODUCTO = new SelectList(db.PRODUCTO, "IDPRODUCTO", "NOMBRE", iNVENTARIO.IDPRODUCTO);
            return View(iNVENTARIO);
        }

        // GET: Inventario/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTARIO iNVENTARIO = db.INVENTARIO.Find(id);
            if (iNVENTARIO == null)
            {
                return HttpNotFound();
            }
            return View(iNVENTARIO);
        }

        // POST: Inventario/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INVENTARIO iNVENTARIO = db.INVENTARIO.Find(id);
            db.INVENTARIO.Remove(iNVENTARIO);
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
