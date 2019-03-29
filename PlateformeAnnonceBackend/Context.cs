using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PlateformeAnnonceBackend.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PlateformeAnnonceBackend
{
    public class Context : DbContext
    {
        public DbSet<Annonce> Annonce { get; set; }
        public DbSet<Categorie> Categorie { get; set; }
        public DbSet<Commentaire> Commentaire { get; set; }
        public DbSet<Notation> Notation { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Utilisateur> Utilisateur { get; set; }
        public DbSet<Favoris> Favoris { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }



}