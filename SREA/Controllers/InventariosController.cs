using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SREA.Models;

namespace SREA.Controllers
{
    public class InventariosController : Controller
    {
        private SREAContext db = new SREAContext();

        // GET: Inventarios
        public ActionResult Index()
        {
            var inventarios = db.Inventarios.Include(i => i.Equipo).Include(i => i.Salon);
            return View(inventarios.ToList());
        }

        // GET: Inventarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventario inventario = db.Inventarios.Find(id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            return View(inventario);
        }

        // GET: Inventarios/Create
        public ActionResult Create()
        {
            ViewBag.ID_Equipo = new SelectList(db.Equipoes, "ID_Equipo", "Tipo_Equipo");
            ViewBag.ID_Salon = new SelectList(db.Salons, "ID_Salon", "Nombre");
            return View();
        }

        // POST: Inventarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Inventario,Descripcion,Cantidad,ID_Salon,ID_Equipo")] Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                db.Inventarios.Add(inventario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Equipo = new SelectList(db.Equipoes, "ID_Equipo", "Tipo_Equipo", inventario.ID_Equipo);
            ViewBag.ID_Salon = new SelectList(db.Salons, "ID_Salon", "Nombre", inventario.ID_Salon);
            return View(inventario);
        }

        // GET: Inventarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventario inventario = db.Inventarios.Find(id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Equipo = new SelectList(db.Equipoes, "ID_Equipo", "Tipo_Equipo", inventario.ID_Equipo);
            ViewBag.ID_Salon = new SelectList(db.Salons, "ID_Salon", "Nombre", inventario.ID_Salon);
            return View(inventario);
        }

        // POST: Inventarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Inventario,Descripcion,Cantidad,ID_Salon,ID_Equipo")] Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Equipo = new SelectList(db.Equipoes, "ID_Equipo", "Tipo_Equipo", inventario.ID_Equipo);
            ViewBag.ID_Salon = new SelectList(db.Salons, "ID_Salon", "Nombre", inventario.ID_Salon);
            return View(inventario);
        }

        // GET: Inventarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventario inventario = db.Inventarios.Find(id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            return View(inventario);
        }

        // POST: Inventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventario inventario = db.Inventarios.Find(id);
            db.Inventarios.Remove(inventario);
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
