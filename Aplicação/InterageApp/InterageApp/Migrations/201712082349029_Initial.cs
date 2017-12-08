namespace InterageApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AreasInteresse",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Interesse = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.Codigo)
                .Index(t => t.Interesse, unique: true, name: "interesse_unq");
            
            CreateTable(
                "dbo.Eventos",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 80),
                        Descricao = c.String(nullable: false, maxLength: 255),
                        CodAreaInteresse = c.Int(nullable: false),
                        DataInicio = c.DateTime(nullable: false),
                        DataFim = c.DateTime(nullable: false),
                        EmailUsuarioPromotor = c.String(nullable: false, maxLength: 50),
                        CodEndereco = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.AreasInteresse", t => t.CodAreaInteresse)
                .ForeignKey("dbo.Usuarios", t => t.EmailUsuarioPromotor)
                .ForeignKey("dbo.Enderecos", t => t.CodEndereco)
                .Index(t => t.CodAreaInteresse)
                .Index(t => t.EmailUsuarioPromotor)
                .Index(t => t.CodEndereco);
            
            CreateTable(
                "dbo.Atividades",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        CodEvento = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 20),
                        DescricaoAtividade = c.String(nullable: false, maxLength: 150),
                        HorarioAtividade = c.DateTime(nullable: false),
                        EmailExpositor = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Eventos", t => t.CodEvento)
                .ForeignKey("dbo.Usuarios", t => t.EmailExpositor)
                .Index(t => t.CodEvento)
                .Index(t => t.EmailExpositor);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 50),
                        Nome = c.String(nullable: false, maxLength: 80),
                        CPF = c.String(nullable: false, maxLength: 11),
                        CodigoPerfil = c.Int(nullable: false),
                        Senha = c.String(nullable: false, maxLength: 25),
                        CodEndereco = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Email)
                .ForeignKey("dbo.Enderecos", t => t.CodEndereco)
                .ForeignKey("dbo.Perfis", t => t.CodigoPerfil)
                .Index(t => t.CodigoPerfil)
                .Index(t => t.CodEndereco);
            
            CreateTable(
                "dbo.Enderecos",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Rua = c.String(nullable: false, maxLength: 100),
                        Complemento = c.String(maxLength: 100),
                        Bairro = c.String(nullable: false, maxLength: 50),
                        Cidade = c.String(nullable: false, maxLength: 50),
                        UF = c.String(nullable: false, maxLength: 2),
                        CEP = c.String(nullable: false, maxLength: 8),
                        Numero = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        CodEvento = c.Int(nullable: false),
                        TipoFeedback = c.String(nullable: false, maxLength: 50),
                        FeedbackMensagem = c.String(nullable: false, maxLength: 4000),
                        EmailUsuario = c.String(nullable: false, maxLength: 50),
                        Evento_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Eventos", t => t.CodEvento, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.EmailUsuario)
                .ForeignKey("dbo.Eventos", t => t.Evento_Codigo)
                .Index(t => t.CodEvento)
                .Index(t => t.EmailUsuario)
                .Index(t => t.Evento_Codigo);
            
            CreateTable(
                "dbo.Perfis",
                c => new
                    {
                        Codigo = c.Int(nullable: false),
                        NomePerfil = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.Codigo)
                .Index(t => t.NomePerfil, unique: true, name: "nome_perfil_unq");
            
            CreateTable(
                "dbo.SalasDiscussoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodAtividade = c.Int(nullable: false),
                        Mensagem = c.String(),
                        EmailUsuario = c.String(maxLength: 50),
                        Hora = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Atividades", t => t.CodAtividade)
                .ForeignKey("dbo.Usuarios", t => t.EmailUsuario)
                .Index(t => t.CodAtividade)
                .Index(t => t.EmailUsuario);
            
            CreateTable(
                "dbo.EventosUsuarios",
                c => new
                    {
                        CodEvento = c.Int(nullable: false),
                        EmailUsuario = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.CodEvento, t.EmailUsuario })
                .ForeignKey("dbo.Eventos", t => t.CodEvento)
                .ForeignKey("dbo.Usuarios", t => t.EmailUsuario)
                .Index(t => t.CodEvento)
                .Index(t => t.EmailUsuario);
            
            CreateTable(
                "dbo.InteressesUsuarios",
                c => new
                    {
                        CodAreaInteresse = c.Int(nullable: false),
                        EmailUsuario = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.CodAreaInteresse, t.EmailUsuario })
                .ForeignKey("dbo.AreasInteresse", t => t.CodAreaInteresse)
                .ForeignKey("dbo.Usuarios", t => t.EmailUsuario)
                .Index(t => t.CodAreaInteresse)
                .Index(t => t.EmailUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalasDiscussoes", "EmailUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.SalasDiscussoes", "CodAtividade", "dbo.Atividades");
            DropForeignKey("dbo.InteressesUsuarios", "EmailUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.InteressesUsuarios", "CodAreaInteresse", "dbo.AreasInteresse");
            DropForeignKey("dbo.EventosUsuarios", "EmailUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.EventosUsuarios", "CodEvento", "dbo.Eventos");
            DropForeignKey("dbo.Feedbacks", "Evento_Codigo", "dbo.Eventos");
            DropForeignKey("dbo.Eventos", "CodEndereco", "dbo.Enderecos");
            DropForeignKey("dbo.Usuarios", "CodigoPerfil", "dbo.Perfis");
            DropForeignKey("dbo.Feedbacks", "EmailUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Feedbacks", "CodEvento", "dbo.Eventos");
            DropForeignKey("dbo.Eventos", "EmailUsuarioPromotor", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "CodEndereco", "dbo.Enderecos");
            DropForeignKey("dbo.Atividades", "EmailExpositor", "dbo.Usuarios");
            DropForeignKey("dbo.Atividades", "CodEvento", "dbo.Eventos");
            DropForeignKey("dbo.Eventos", "CodAreaInteresse", "dbo.AreasInteresse");
            DropIndex("dbo.InteressesUsuarios", new[] { "EmailUsuario" });
            DropIndex("dbo.InteressesUsuarios", new[] { "CodAreaInteresse" });
            DropIndex("dbo.EventosUsuarios", new[] { "EmailUsuario" });
            DropIndex("dbo.EventosUsuarios", new[] { "CodEvento" });
            DropIndex("dbo.SalasDiscussoes", new[] { "EmailUsuario" });
            DropIndex("dbo.SalasDiscussoes", new[] { "CodAtividade" });
            DropIndex("dbo.Perfis", "nome_perfil_unq");
            DropIndex("dbo.Feedbacks", new[] { "Evento_Codigo" });
            DropIndex("dbo.Feedbacks", new[] { "EmailUsuario" });
            DropIndex("dbo.Feedbacks", new[] { "CodEvento" });
            DropIndex("dbo.Usuarios", new[] { "CodEndereco" });
            DropIndex("dbo.Usuarios", new[] { "CodigoPerfil" });
            DropIndex("dbo.Atividades", new[] { "EmailExpositor" });
            DropIndex("dbo.Atividades", new[] { "CodEvento" });
            DropIndex("dbo.Eventos", new[] { "CodEndereco" });
            DropIndex("dbo.Eventos", new[] { "EmailUsuarioPromotor" });
            DropIndex("dbo.Eventos", new[] { "CodAreaInteresse" });
            DropIndex("dbo.AreasInteresse", "interesse_unq");
            DropTable("dbo.InteressesUsuarios");
            DropTable("dbo.EventosUsuarios");
            DropTable("dbo.SalasDiscussoes");
            DropTable("dbo.Perfis");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Enderecos");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Atividades");
            DropTable("dbo.Eventos");
            DropTable("dbo.AreasInteresse");
        }
    }
}
