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
using PlateformeAnnonceBackend;
using PlateformeAnnonceBackend.Models;

namespace PlateformeAnnonceBackend.Controllers
{
    public class NotationsController : ApiController
    {
        private Context db = new Context();

        // GET: api/Notations
        public IQueryable<Notation> GetNotation()
        {
            return db.Notation;
        }

        // GET: api/Notations/5
        [ResponseType(typeof(Notation))]
        public IHttpActionResult GetNotation(int id)
        {
            Notation notation = db.Notation.Find(id);
            if (notation == null)
            {
                return NotFound();
            }

            return Ok(notation);
        }

        // PUT: api/Notations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNotation(int id, Notation notation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notation.Id)
            {
                return BadRequest();
            }

            db.Entry(notation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotationExists(id))
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

        // POST: api/Notations
        [ResponseType(typeof(Notation))]
        public IHttpActionResult PostNotation(Notation notation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Notation.Add(notation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = notation.Id }, notation);
        }

        // DELETE: api/Notations/5
        [ResponseType(typeof(Notation))]
        public IHttpActionResult DeleteNotation(int id)
        {
            Notation notation = db.Notation.Find(id);
            if (notation == null)
            {
                return NotFound();
            }

            db.Notation.Remove(notation);
            db.SaveChanges();

            return Ok(notation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NotationExists(int id)
        {
            return db.Notation.Count(e => e.Id == id) > 0;
        }
    }
}