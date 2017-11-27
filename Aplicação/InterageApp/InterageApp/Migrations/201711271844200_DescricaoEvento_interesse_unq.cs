namespace InterageApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescricaoEvento_interesse_unq : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Eventos", "Descricao", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.AreasInteresse", "Interesse", unique: true, name: "interesse_unq");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AreasInteresse", "interesse_unq");
            DropColumn("dbo.Eventos", "Descricao");
        }
    }
}
