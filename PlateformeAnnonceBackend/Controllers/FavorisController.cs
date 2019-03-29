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
    public class FavorisController : ApiController
    {
        private Context db = new Context();

        // GET: api/Favoris
        public IQueryable<Favoris> GetFavoris()
        {
            return db.Favoris;
        }

        // GET: api/Favoris/5
        [ResponseType(typeof(Favoris))]
        public IHttpActionResult GetFavoris(int id)
        {
            Favoris favoris = db.Favoris.Find(id);
            if (favoris == null)
            {
                return NotFound();
            }

            return Ok(favoris);
        }

        // PUT: api/Favoris/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFavoris(int id, Favoris favoris)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != favoris.Id)
            {
                return BadRequest();
            }

            db.Entry(favoris).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavorisExists(id))
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

        // POST: api/Favoris
        [ResponseType(typeof(Favoris))]
        public IHttpActionResult PostFavoris(Favoris favoris)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Favoris.Add(favoris);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = favoris.Id }, favoris);
        }

        // DELETE: api/Favoris/5
        [ResponseType(typeof(Favoris))]
        public IHttpActionResult DeleteFavoris(int id)
        {
            Favoris favoris = db.Favoris.Find(id);
            if (favoris == null)
            {
                return NotFound();
            }

            db.Favoris.Remove(favoris);
            db.SaveChanges();

            return Ok(favoris);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FavorisExists(int id)
        {
            return db.Favoris.Count(e => e.Id == id) > 0;
        }

        /* Api pour lister les annonces d'un utilisateur */
        // GET: api/ImageAnnonce
        [HttpGet, Route("api/getFavorisByUtilisateur/{UtilisateurID}")]
        public IHttpActionResult getFavoriseByUtilisateur(int UtilisateurID)
        {
            var annonces = from f in db.Favoris
                                       join a in db.Annonce on f.AnnonceID equals a.Id
                                       where f.UtilisateurID == UtilisateurID
                                       select a;

            if (annonces == null)
            {
                return NotFound();
            }

            return Ok(annonces);
        }
    }
}