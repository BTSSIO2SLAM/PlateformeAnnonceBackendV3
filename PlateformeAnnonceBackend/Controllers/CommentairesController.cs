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
    public class CommentairesController : ApiController
    {
        private Context db = new Context();

        // GET: api/Commentaires
        public IQueryable<Commentaire> GetCommentaire()
        {
            return db.Commentaire;
        }

        // GET: api/Commentaires/5
        [ResponseType(typeof(Commentaire))]
        public IHttpActionResult GetCommentaire(int id)
        {
            Commentaire commentaire = db.Commentaire.Find(id);
            if (commentaire == null)
            {
                return NotFound();
            }

            return Ok(commentaire);
        }

        // PUT: api/Commentaires/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCommentaire(int id, Commentaire commentaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commentaire.Id)
            {
                return BadRequest();
            }

            db.Entry(commentaire).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentaireExists(id))
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

        // POST: api/Commentaires
        [ResponseType(typeof(Commentaire))]
        public IHttpActionResult PostCommentaire(Commentaire commentaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Commentaire.Add(commentaire);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = commentaire.Id }, commentaire);
        }

        // DELETE: api/Commentaires/5
        [ResponseType(typeof(Commentaire))]
        public IHttpActionResult DeleteCommentaire(int id)
        {
            Commentaire commentaire = db.Commentaire.Find(id);
            if (commentaire == null)
            {
                return NotFound();
            }

            db.Commentaire.Remove(commentaire);
            db.SaveChanges();

            return Ok(commentaire);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommentaireExists(int id)
        {
            return db.Commentaire.Count(e => e.Id == id) > 0;
        }
    }
}