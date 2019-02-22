using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlateformeAnnonceBackend.Models
{
    [Table("Annonce")]
    public class Annonce
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Titre { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public int Prix { get; set; }

        [Required]
        public string UrlPhoto { get; set; }

        public int UtilisateurID { get; set; }

        [ForeignKey("UtilisateurID")]
        public virtual Utilisateur Utilisateur { get; set; }

        public int CategorieID { get; set; }

        [ForeignKey("CategorieID")]
        public virtual Categorie Categorie { get; set; }

        public Annonce() { }

        public Annonce(int id, string titre, string details, int prix, string urlPhoto, Utilisateur utilisateur, Categorie categorie)
        {
            Id = id;
            Titre = titre;
            Details = details;
            Prix = prix;
            UrlPhoto = urlPhoto;
            Utilisateur = utilisateur;
            Categorie = categorie;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}