namespace PlateformeAnnonceBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Annonce",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titre = c.String(nullable: false),
                        Details = c.String(nullable: false),
                        Prix = c.Int(nullable: false),
                        UrlPhoto = c.String(nullable: false),
                        Categorie_Id = c.Int(nullable: false),
                        Utilisateur_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorie", t => t.Categorie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Utilisateur", t => t.Utilisateur_Id, cascadeDelete: true)
                .Index(t => t.Categorie_Id)
                .Index(t => t.Utilisateur_Id);
            
            CreateTable(
                "dbo.Categorie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Utilisateur",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Prenom = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Commentaire",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Contenu = c.String(nullable: false),
                        Annonce_Id = c.Int(nullable: false),
                        Notation_Id = c.Int(nullable: false),
                        Utilisateur_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Annonce", t => t.Annonce_Id, cascadeDelete: true)
                .ForeignKey("dbo.Notation", t => t.Notation_Id, cascadeDelete: true)
                .ForeignKey("dbo.Utilisateur", t => t.Utilisateur_Id, cascadeDelete: true)
                .Index(t => t.Annonce_Id)
                .Index(t => t.Notation_Id)
                .Index(t => t.Utilisateur_Id);
            
            CreateTable(
                "dbo.Notation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Note = c.Int(nullable: false),
                        Libelle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(nullable: false),
                        Url = c.String(nullable: false),
                        Annonce_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Annonce", t => t.Annonce_Id, cascadeDelete: true)
                .Index(t => t.Annonce_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photo", "Annonce_Id", "dbo.Annonce");
            DropForeignKey("dbo.Commentaire", "Utilisateur_Id", "dbo.Utilisateur");
            DropForeignKey("dbo.Commentaire", "Notation_Id", "dbo.Notation");
            DropForeignKey("dbo.Commentaire", "Annonce_Id", "dbo.Annonce");
            DropForeignKey("dbo.Annonce", "Utilisateur_Id", "dbo.Utilisateur");
            DropForeignKey("dbo.Annonce", "Categorie_Id", "dbo.Categorie");
            DropIndex("dbo.Photo", new[] { "Annonce_Id" });
            DropIndex("dbo.Commentaire", new[] { "Utilisateur_Id" });
            DropIndex("dbo.Commentaire", new[] { "Notation_Id" });
            DropIndex("dbo.Commentaire", new[] { "Annonce_Id" });
            DropIndex("dbo.Annonce", new[] { "Utilisateur_Id" });
            DropIndex("dbo.Annonce", new[] { "Categorie_Id" });
            DropTable("dbo.Photo");
            DropTable("dbo.Notation");
            DropTable("dbo.Commentaire");
            DropTable("dbo.Utilisateur");
            DropTable("dbo.Categorie");
            DropTable("dbo.Annonce");
        }
    }
}
