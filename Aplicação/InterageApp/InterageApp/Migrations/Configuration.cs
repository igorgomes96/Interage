namespace InterageApp.Migrations
{
    using InterageApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InterageApp.Models.Modelo>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InterageApp.Models.Modelo context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Perfis.AddOrUpdate(
                new Perfil { Codigo = 1, NomePerfil = "Promotor" },
                new Perfil { Codigo = 2, NomePerfil = "Padrão" }
            );
        }
    }
}
