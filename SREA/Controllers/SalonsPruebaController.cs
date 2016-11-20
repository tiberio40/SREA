using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SREA.Models;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SREA.Controllers
{
    public class SalonsPruebaController : Controller
    {
        private SREAContext db = new SREAContext();

        public ActionResult GeneratePDF()
        {
            return new Rotativa.ActionAsPdf("GetPersons");
        }

        public byte[] GetPDF(string pHTML)
        {
            byte[] bPDF = null;

            MemoryStream ms = new MemoryStream();
            TextReader txtReader = new StringReader(pHTML);

            // 1: create object of a itextsharp document class
            Document doc = new Document(PageSize.A4, 25, 25, 25, 25);

            // 2: we create a itextsharp pdfwriter that listens to the document and directs a XML-stream to a file
            PdfWriter oPdfWriter = PdfWriter.GetInstance(doc, ms);

            // 3: we create a worker parse the document
            HTMLWorker htmlWorker = new HTMLWorker(doc);

            // 4: we open document and start the worker on the document
            doc.Open();
            htmlWorker.StartDocument();

            // 5: parse the html into the document
            htmlWorker.Parse(txtReader);

            // 6: close the document and the worker
            htmlWorker.EndDocument();
            htmlWorker.Close();
            doc.Close();

            bPDF = ms.ToArray();

            return bPDF;
        }

        public void DownloadPDF()
        {
            string Contenido;
            string HTMLContent = "<table><tr><th>Firstname</th><th>Lastname</th><th>Age</th></tr><tr><td>Jill</td><td>Smith</td><td>50</td></tr><tr><td>Eve</td><td>Jackson</td><td>94</td></tr><tr><td>John</td><td>Doe</td><td>80</td></tr></table>";
            //List<Salon> consulta = new List<Salon>();
            Salon salon = db.Salons.Find(1);
            Contenido = salon.Nombre +" "+salon.Descripcion;
            /*foreach (var baseDeDatos in db.Salons)
            {
                Contenido = baseDeDatos.Nombre;
                Contenido = Contenido + " " + baseDeDatos.Descripcion;
                Contenido = Contenido + "</br>";
            }*/
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + "PDFfile.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(GetPDF(HTMLContent));
            Response.End();
        }

        // GET: SalonsPrueba
        public ActionResult Index()
        {
            
            return View(@"C:\Users\Laurent Castañeda\Documents\GitHub\SREA\SREA\img\19882_581bdc3d89943(2).jpg");
        }

        // GET: SalonsPrueba/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salon salon = db.Salons.Find(id);
            if (salon == null)
            {
                return HttpNotFound();
            }
            return View(salon);
        }

        // GET: SalonsPrueba/Create
        public ActionResult Create()
        {
            ViewBag.ID_Edificio = new SelectList(db.Edificios, "ID_Edificio", "Nombre");
            return View();
        }

        // POST: SalonsPrueba/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Salon,Nombre,Capacidad,Descripcion,Imagen,ID_Edificio")] Salon salon)
        {
            if (ModelState.IsValid)
            {
                db.Salons.Add(salon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Edificio = new SelectList(db.Edificios, "ID_Edificio", "Nombre", salon.ID_Edificio);
            return View(salon);
        }

        // GET: SalonsPrueba/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salon salon = db.Salons.Find(id);
            if (salon == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Edificio = new SelectList(db.Edificios, "ID_Edificio", "Nombre", salon.ID_Edificio);
            return View(salon);
        }

        // POST: SalonsPrueba/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Salon,Nombre,Capacidad,Descripcion,Imagen,ID_Edificio")] Salon salon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Edificio = new SelectList(db.Edificios, "ID_Edificio", "Nombre", salon.ID_Edificio);
            return View(salon);
        }

        // GET: SalonsPrueba/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salon salon = db.Salons.Find(id);
            if (salon == null)
            {
                return HttpNotFound();
            }
            return View(salon);
        }

        // POST: SalonsPrueba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salon salon = db.Salons.Find(id);
            db.Salons.Remove(salon);
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
