using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SREA.Models;

namespace SREA.Controllers
{
    public class EdificiosApiController : ApiController
    {
        private SREAContext db = new SREAContext();

        // GET: api/EdificiosApi
        public List<Edificio> GetEdificios()
        {
            int i = 0;
            List<Edificio> listaConsultada = new List<Edificio>();
            Edificio consulta = new Edificio();
            foreach (Edificio c in db.Edificios)
            {
                listaConsultada.Add(new Edificio());
                listaConsultada[i].ID_Edificio = c.ID_Edificio;
                listaConsultada[i].Nombre = c.Nombre;
                //listaConsultada.Add(consulta);
                i++;
            }
            return listaConsultada;
         
        }

        // GET: api/EdificiosApi/5
        [ResponseType(typeof(Edificio))]
        public IHttpActionResult GetEdificio(int id)
        {
            Edificio edificio = db.Edificios.Find(id);
            if (edificio == null)
            {
                return NotFound();
            }

            return Ok(edificio);
        }

        // PUT: api/EdificiosApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEdificio(int id, Edificio edificio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != edificio.ID_Edificio)
            {
                return BadRequest();
            }

            db.Entry(edificio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EdificioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EdificiosApi
        [ResponseType(typeof(Edificio))]
        public IHttpActionResult PostEdificio(Edificio edificio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Edificios.Add(edificio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = edificio.ID_Edificio }, edificio);
        }

        // DELETE: api/EdificiosApi/5
        [ResponseType(typeof(Edificio))]
        public IHttpActionResult DeleteEdificio(int id)
        {
            Edificio edificio = db.Edificios.Find(id);
            if (edificio == null)
            {
                return NotFound();
            }

            db.Edificios.Remove(edificio);
            db.SaveChanges();

            return Ok(edificio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EdificioExists(int id)
        {
            return db.Edificios.Count(e => e.ID_Edificio == id) > 0;
        }
    }
}