namespace DnDSpellBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Spells",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        _id = c.String(),
                        index = c.String(),
                        name = c.String(),
                        page = c.String(),
                        range = c.String(),
                        material = c.String(),
                        ritual = c.String(),
                        duration = c.String(),
                        concentration = c.String(),
                        casting_time = c.String(),
                        level = c.String(),
                        url = c.String(),
                        school_Id = c.Int(),
                        Character_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.school_Id)
                .ForeignKey("dbo.Characters", t => t.Character_Id)
                .Index(t => t.school_Id)
                .Index(t => t.Character_Id);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        url = c.String(),
                        Spell_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Spells", t => t.Spell_Id)
                .Index(t => t.Spell_Id);
            
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
                "dbo.Subclasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        url = c.String(),
                        name = c.String(),
                        Spell_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Spells", t => t.Spell_Id)
                .Index(t => t.Spell_Id);
            
            CreateTable(
                "dbo.SpellLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        url = c.String(),
                        SpellList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SpellLists", t => t.SpellList_Id)
                .Index(t => t.SpellList_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "SpellList_Id", "dbo.SpellLists");
            DropForeignKey("dbo.Spells", "Character_Id", "dbo.Characters");
            DropForeignKey("dbo.Subclasses", "Spell_Id", "dbo.Spells");
            DropForeignKey("dbo.Spells", "school_Id", "dbo.Schools");
            DropForeignKey("dbo.Classes", "Spell_Id", "dbo.Spells");
            DropIndex("dbo.Results", new[] { "SpellList_Id" });
            DropIndex("dbo.Subclasses", new[] { "Spell_Id" });
            DropIndex("dbo.Classes", new[] { "Spell_Id" });
            DropIndex("dbo.Spells", new[] { "Character_Id" });
            DropIndex("dbo.Spells", new[] { "school_Id" });
            DropTable("dbo.Results");
            DropTable("dbo.SpellLists");
            DropTable("dbo.Subclasses");
            DropTable("dbo.Schools");
            DropTable("dbo.Classes");
            DropTable("dbo.Spells");
            DropTable("dbo.Characters");
        }
    }
}
