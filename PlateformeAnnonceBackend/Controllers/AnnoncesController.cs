using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json.Linq;
using PlateformeAnnonceBackend.Models;

namespace PlateformeAnnonceBackend.Controllers
{
    public class AnnoncesController : ApiController
    {
        private Context db = new Context();

        // GET: api/Annonces
        public IQueryable<Annonce> GetAnnonce() {
            return db.Annonce.OrderByDescending(x => x.Id);
        }

        // GET: api/Annonces/5
        [ResponseType(typeof(Annonce))]
        public IHttpActionResult GetAnnonce(int id) {
            Annonce annonce = db.Annonce.Find(id);
            if (annonce == null) {
                return NotFound();
            }
            return Ok(annonce);
        }

        // PUT: api/Annonces/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnnonce(int id, Annonce annonce) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            if (id != annonce.Id) {
                return BadRequest();
            }
            db.Entry(annonce).State = EntityState.Modified;
            try {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException) {
                if (!AnnonceExists(id)) {
                    return NotFound();
                }
                else {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Annonces
        [ResponseType(typeof(Annonce))]
        public IHttpActionResult PostAnnonce(Annonce annonce) {
            String filePath = "";
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0) {               
                foreach (string file in httpRequest.Files) {
                    var postedFile = httpRequest.Files[file];
                    filePath = HttpContext.Current.Server.MapPath("~/assets/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                    // NOTE: To store in memory use postedFile.InputStream
                    filePath = "http://localhost:59825/Assets/" + postedFile.FileName;
                }
            }
            //Image
            annonce.UrlPhoto = filePath;
            //Categorie
            Categorie categorie = db.Categorie.Find(annonce.CategorieID);
            annonce.Categorie = categorie;

            //Utilisateur
            Utilisateur utilisateur = db.Utilisateur.Find(annonce.UtilisateurID);
            annonce.Utilisateur = utilisateur;
            
            //db.Categorie.Attach(annonce.Categorie);
            //db.Utilisateur.Attach(annonce.Utilisateur);

            db.Annonce.Add(annonce);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = annonce.Id }, annonce);
        }

        /* Api pour uploader une image */
        // POST: api/ImageAnnonce
        [HttpPost, Route("api/upload")]
        public IHttpActionResult Post()
        {
            var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count < 1)
            {
                return BadRequest();
            }

            Annonce annonce = new Annonce();

            JObject json = JObject.Parse(httpRequest.Form[0]);
            annonce = json.ToObject<Annonce>();

            String filePath = "";

            foreach (string file in httpRequest.Files)
            {
                var postedFile = httpRequest.Files[file];
                filePath = HttpContext.Current.Server.MapPath("~/assets/" + postedFile.FileName);
                postedFile.SaveAs(filePath);
                // NOTE: To store in memory use postedFile.InputStream
                filePath = "http://localhost:59825/Assets/" + postedFile.FileName;
            }

            annonce.UrlPhoto = filePath;

            db.Annonce.Add(annonce);
            db.SaveChanges();

            return Ok(annonce);
        }

        /* Api pour lister les annonces d'un utilisateur */
        // GET: api/ImageAnnonce
        [HttpGet, Route("api/getAnnonceByUtilisateur/{UtilisateurID}")]
        public IHttpActionResult getAnnonceByUtilisateur(int UtilisateurID)
        {
            var annonces = db.Annonce
                        .Where(s => s.UtilisateurID == UtilisateurID);

            if (annonces == null)
            {
                return NotFound();
            }

            return Ok(annonces);
        }

        // DELETE: api/Annonces/5
        [ResponseType(typeof(Annonce))]
        public IHttpActionResult DeleteAnnonce(int id)
        {
            Annonce annonce = db.Annonce.Find(id);
            if (annonce == null)
            {
                return NotFound();
            }

            db.Annonce.Remove(annonce);
            db.SaveChanges();

            return Ok(annonce);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnnonceExists(int id)
        {
            return db.Annonce.Count(e => e.Id == id) > 0;
        }
    }
}