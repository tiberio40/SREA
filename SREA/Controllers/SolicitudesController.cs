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
    public class SolicitudesController : Controller
    {
        private SREAContext db = new SREAContext();

        public ActionResult GeneratePDF()
        {
            return new Rotativa.ActionAsPdf("Lista");
        }

        // GET: Solicitudes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista()
        {
            var solicituds = db.Solicituds.Include(s => s.Persona).Include(s => s.Salon);
            return View(solicituds.ToList());
        }

        public ActionResult Modificar()
        {
            try
            {
                if (Session["ID_Persona"] != null)
                {
                    var solicituds = db.Solicituds.Include(s => s.Persona).Include(s => s.Salon);
                    return View(solicituds.ToList());
                }
                else
                {
                    return RedirectToAction("Index", "Home");

                }
            }catch(Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        //.Where(x => x.ID_Persona == (int)Session["ID_Persona"])
        // GET: Solicitudes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud solicitud = db.Solicituds.Find(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            return View(solicitud);
        }

        // GET: Solicitudes/Create
        public ActionResult Create()
        {
            if (Session["Nick"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ID_Persona = new SelectList(db.Personas, "ID_Persona", "Nick");
                ViewBag.ID_Salon = new SelectList(db.Salons, "ID_Salon", "Nombre");
                return View();
            }
            
        }

        // POST: Solicitudes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Solicitud,Tema,Cantidad_Inscritos,Fecha_Solicitud,Estado,ID_Salon,ID_Persona")] Solicitud solicitud)
        {
            if (Session["Nick"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var consulta = db.Salons.Find(solicitud.ID_Salon);
                    
                    if (Session["Privilegio"].Equals("3"))
                    {
                        if (consulta.Capacidad >= solicitud.Cantidad_Inscritos)
                        {
                            db.Solicituds.Add(solicitud);
                            db.SaveChanges();
                            return RedirectToAction("Create", "Dia_Apartado");
                        }
                        
                    }
                    else
                    {
                       

                        if (consulta.Capacidad >= solicitud.Cantidad_Inscritos)
                        {
                            db.Solicituds.Add(solicitud).ID_Persona = Convert.ToInt16(Session["ID_Persona"]);
                            db.Solicituds.Add(solicitud).Estado = false;
                            db.SaveChanges();
                            return RedirectToAction("Create", "Dia_Apartado");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Salon no tiene esa capacidad");
                        }
                        
                    }
                    
                    
                }

                ViewBag.ID_Persona = new SelectList(db.Personas, "ID_Persona", "Nick", solicitud.ID_Persona);
                ViewBag.ID_Salon = new SelectList(db.Salons, "ID_Salon", "Nombre", solicitud.ID_Salon);
                return View(solicitud);
            }

            
        }

        // GET: Solicitudes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Nick"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Solicitud solicitud = db.Solicituds.Find(id);
                if (solicitud == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ID_Persona = new SelectList(db.Personas, "ID_Persona", "Nick", solicitud.ID_Persona);
                ViewBag.ID_Salon = new SelectList(db.Salons, "ID_Salon", "Nombre", solicitud.ID_Salon);
                return View(solicitud);
            }
           
        }

        // POST: Solicitudes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Solicitud,Tema,Cantidad_Inscritos,Fecha_Solicitud,Estado,ID_Salon,ID_Persona")] Solicitud solicitud)
        {
            if (Session["Nick"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (ModelState.IsValid)
                {

                    if (Session["Privilegio"].Equals("3"))
                    {
                        db.Entry(solicitud).State = EntityState.Modified;
                    }
                    else
                    {
                        solicitud.ID_Persona = Convert.ToInt16(Session["ID_Persona"]);
                        solicitud.Estado = false;
                        db.Entry(solicitud).State = EntityState.Modified;
                    }
                    db.Entry(solicitud).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ID_Persona = new SelectList(db.Personas, "ID_Persona", "Nick", solicitud.ID_Persona);
                ViewBag.ID_Salon = new SelectList(db.Salons, "ID_Salon", "Nombre", solicitud.ID_Salon);
                return View(solicitud);
            }
           
        }

        // GET: Solicitudes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud solicitud = db.Solicituds.Find(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            return View(solicitud);
        }

        // POST: Solicitudes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Solicitud solicitud = db.Solicituds.Find(id);
            db.Solicituds.Remove(solicitud);
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
