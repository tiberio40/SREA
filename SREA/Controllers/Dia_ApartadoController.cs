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
    public class Dia_ApartadoController : Controller
    {
        private SREAContext db = new SREAContext();

        // GET: Dia_Apartado
        public ActionResult Index()
        {
            var dia_Apartado = db.Dia_Apartado.Include(d => d.Solicitud);
            return View(dia_Apartado.ToList());
        }

        // GET: Dia_Apartado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dia_Apartado dia_Apartado = db.Dia_Apartado.Find(id);
            if (dia_Apartado == null)
            {
                return HttpNotFound();
            }
            return View(dia_Apartado);
        }

        // GET: Dia_Apartado/Create
        public ActionResult Create()
        {
            ViewBag.ID_Solicitud = new SelectList(db.Solicituds, "ID_Solicitud", "Tema");
            return View();
        }

        // POST: Dia_Apartado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Dia_Apartado,Fecha_Apartada,Hora_Comienzo,Hora_Terminado,ID_Solicitud")] Dia_Apartado dia_Apartado)
        {
            if (ModelState.IsValid)
            {
                db.Dia_Apartado.Add(dia_Apartado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Solicitud = new SelectList(db.Solicituds, "ID_Solicitud", "Tema", dia_Apartado.ID_Solicitud);
            return View(dia_Apartado);
        }

        // GET: Dia_Apartado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dia_Apartado dia_Apartado = db.Dia_Apartado.Find(id);
            if (dia_Apartado == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Solicitud = new SelectList(db.Solicituds, "ID_Solicitud", "Tema", dia_Apartado.ID_Solicitud);
            return View(dia_Apartado);
        }

        // POST: Dia_Apartado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Dia_Apartado,Fecha_Apartada,Hora_Comienzo,Hora_Terminado,ID_Solicitud")] Dia_Apartado dia_Apartado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dia_Apartado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Solicitud = new SelectList(db.Solicituds, "ID_Solicitud", "Tema", dia_Apartado.ID_Solicitud);
            return View(dia_Apartado);
        }

        // GET: Dia_Apartado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dia_Apartado dia_Apartado = db.Dia_Apartado.Find(id);
            if (dia_Apartado == null)
            {
                return HttpNotFound();
            }
            return View(dia_Apartado);
        }

        // POST: Dia_Apartado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dia_Apartado dia_Apartado = db.Dia_Apartado.Find(id);
            db.Dia_Apartado.Remove(dia_Apartado);
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
