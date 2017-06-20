namespace DnDSpellBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedmodels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Classes", "Spell_Id", "dbo.Spells");
            DropForeignKey("dbo.Spells", "school_Id", "dbo.Schools");
            DropForeignKey("dbo.Subclasses", "Spell_Id", "dbo.Spells");
            DropIndex("dbo.Spells", new[] { "school_Id" });
            DropIndex("dbo.Classes", new[] { "Spell_Id" });
            DropIndex("dbo.Subclasses", new[] { "Spell_Id" });
            DropColumn("dbo.Spells", "school_Id");
            DropTable("dbo.Classes");
            DropTable("dbo.Schools");
            DropTable("dbo.Subclasses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Subclasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        url = c.String(),
                        name = c.String(),
                        Spell_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        url = c.String(),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        url = c.String(),
                        Spell_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Spells", "school_Id", c => c.Int());
            CreateIndex("dbo.Subclasses", "Spell_Id");
            CreateIndex("dbo.Classes", "Spell_Id");
            CreateIndex("dbo.Spells", "school_Id");
            AddForeignKey("dbo.Subclasses", "Spell_Id", "dbo.Spells", "Id");
            AddForeignKey("dbo.Spells", "school_Id", "dbo.Schools", "Id");
            AddForeignKey("dbo.Classes", "Spell_Id", "dbo.Spells", "Id");
        }
    }
}
