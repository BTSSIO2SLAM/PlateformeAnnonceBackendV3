using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlateformeAnnonceBackend.Models
{
    [Table("Photo")]
    public class Photo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Libelle { get; set; }

        [Required]
        public string Url { get; set; }

        public int AnnonceID { get; set; }

        [ForeignKey("AnnonceID")]
        public Annonce Annonce { get; set; }
    }
}