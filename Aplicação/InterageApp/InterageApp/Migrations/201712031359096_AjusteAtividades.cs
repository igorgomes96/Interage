namespace InterageApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjusteAtividades : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Atividades", "Nome", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Atividades", "Endereco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Atividades", "Endereco", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Atividades", "Nome");
        }
    }
}
