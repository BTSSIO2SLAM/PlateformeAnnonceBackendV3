using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PlateformeAnnonceBackend.Models
{
    [Table("Favoris")]
    public class Favoris
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UtilisateurID { get; set; }

        [ForeignKey("UtilisateurID")]
        public Utilisateur Utilisateur { get; set; }

        public int AnnonceID { get; set; }

        [ForeignKey("AnnonceID")]
        public Annonce Annonce { get; set; }



    }
}