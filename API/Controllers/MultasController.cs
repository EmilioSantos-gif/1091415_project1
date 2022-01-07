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
using BO;

namespace API.Controllers
{
    public class MultasController : ApiController
    {
        private MultaEntities1 db = new MultaEntities1();

        // GET: api/Multas
        public IQueryable<Multa> GetMulta()
        {
            return db.Multa;
        }

        // GET: api/Multas/5
        [ResponseType(typeof(Multa))]
        public IHttpActionResult GetMulta(string id)
        {
            Multa multa = db.Multa.Find(id);
            if (multa == null)
            {
                return NotFound();
            }

            return Ok(multa);
        }

        // PUT: api/Multas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMulta(string id, Multa multa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != multa.Acta)
            {
                return BadRequest();
            }

            db.Entry(multa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MultaExists(id))
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

        // POST: api/Multas
        [ResponseType(typeof(Multa))]
        public IHttpActionResult PostMulta(Multa multa)
        {
            multa.Id = Guid.NewGuid();
            multa.Fecha = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Multa.Add(multa);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MultaExists(multa.Acta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = multa.Acta }, multa);
        }

        // DELETE: api/Multas/5
        [ResponseType(typeof(Multa))]
        public IHttpActionResult DeleteMulta(string id)
        {
            Multa multa = db.Multa.Find(id);
            if (multa == null)
            {
                return NotFound();
            }

            db.Multa.Remove(multa);
            db.SaveChanges();

            return Ok(multa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MultaExists(string id)
        {
            return db.Multa.Count(e => e.Acta == id) > 0;
        }
    }
}