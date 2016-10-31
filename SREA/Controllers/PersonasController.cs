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
    public class PersonasController : Controller
    {
        private SREAContext db = new SREAContext();

        // GET: Personas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Administrar()
        {
            return View();
        }

        public ActionResult Listado_Usuarios()
        {
            var personas = db.Personas.Include(p => p.Tipo_Usuario);
            return View(personas.ToList());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            ViewBag.ID_Tipo_Usuario = new SelectList(db.Tipo_Usuario, "ID_Tipo_Usuario", "Descripcion");
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Persona,Nick,Nombre,Apellidos,Telefono,Email,Clave,ID_Tipo_Usuario")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Personas.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Tipo_Usuario = new SelectList(db.Tipo_Usuario, "ID_Tipo_Usuario", "Descripcion", persona.ID_Tipo_Usuario);
            return View(persona);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Tipo_Usuario = new SelectList(db.Tipo_Usuario, "ID_Tipo_Usuario", "Descripcion", persona.ID_Tipo_Usuario);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Persona,Nick,Nombre,Apellidos,Telefono,Email,Clave,ID_Tipo_Usuario")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Tipo_Usuario = new SelectList(db.Tipo_Usuario, "ID_Tipo_Usuario", "Descripcion", persona.ID_Tipo_Usuario);
            return View(persona);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Personas.Find(id);
            db.Personas.Remove(persona);
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

        //INGRESAR A LA CUENTA - REDIRECCION

        public ActionResult Login()
        {
            if (Session["ID_Persona"] != null)
            {
                return RedirectToAction("Loggedin");
            }
            else
            {
                return View();
            }
        }

        //INGRESAR A LA CUENTA - FORMULARIO INGRESO

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Persona user)
        {
            var usr = db.Personas.Where(x => x.Nick == user.Nick && x.Clave == user.Clave).FirstOrDefault();
            if (usr != null)
            {
                Session["ID_Persona"] = usr.ID_Persona.ToString();
                Session["Nick"] = usr.Nick.ToString();
                Session["Nombre_Usuario"] = usr.Nombre.ToString() + " " + usr.Apellidos.ToString();
                Session["Privilegio"] = usr.ID_Tipo_Usuario.ToString();
                return RedirectToAction("Loggedin");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password estan mal");
            }
            return View();
        }

        //CONFIRMACION INGRESO

        public ActionResult Loggedin()
        {
            if (Session["ID_Persona"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public ActionResult LoginOut()
        {
            if (Session["ID_Persona"] == null)
            {
                return RedirectToAction("Login");
                
            }
            else
            {
                return View();
            }
        }

        //INGRESAR A LA CUENTA - FORMULARIO INGRESO

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginOut(Persona user)
        {
            if (Session["ID_Persona"] != null)
            {
                Session["ID_Persona"] = null;
                Session["Nick"] = null;
                Session["Nombre_Usuario"] = null;
                return RedirectToAction("Login");
            }

            return View();
        }

    }
}
