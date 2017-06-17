namespace DnDSpellBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Spells", "Character_Id", "dbo.Characters");
            DropIndex("dbo.Spells", new[] { "Character_Id" });
            AlterColumn("dbo.Spells", "Character_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Spells", "Character_Id");
            AddForeignKey("dbo.Spells", "Character_Id", "dbo.Characters", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Spells", "Character_Id", "dbo.Characters");
            DropIndex("dbo.Spells", new[] { "Character_Id" });
            AlterColumn("dbo.Spells", "Character_Id", c => c.Int());
            CreateIndex("dbo.Spells", "Character_Id");
            AddForeignKey("dbo.Spells", "Character_Id", "dbo.Characters", "Id");
        }
    }
}
