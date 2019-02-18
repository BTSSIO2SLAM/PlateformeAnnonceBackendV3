using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlateformeAnnonceBackend.Models
{
    [Table("Commentaire")]
    public class Commentaire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Contenu { get; set; }

        public int UtilisateurID { get; set; }

        [ForeignKey("UtilisateurID")]
        public Utilisateur Utilisateur { get; set; }

        public int AnnonceID { get; set; }

        [ForeignKey("AnnonceID")]
        public Annonce Annonce { get; set; }

        public int NotationID { get; set; }

        [ForeignKey("NotationID")]
        public Notation Notation { get; set; }


    }
}