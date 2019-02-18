using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlateformeAnnonceBackend.Models
{
    [Table("Notation")]
    public class Notation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Note { get; set; }

        [Required]
        public string Libelle { get; set; }
    }
}