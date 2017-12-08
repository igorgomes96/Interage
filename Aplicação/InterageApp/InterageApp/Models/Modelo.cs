namespace InterageApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class Modelo : DbContext
    {

        public Modelo()
            : base("name=Modelo")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Evento>()
                .HasMany(c => c.Participantes)
                .WithMany(c => c.EventosInscritos)
                .Map(x =>
                {
                    x.MapLeftKey("CodEvento");
                    x.MapRightKey("EmailUsuario");
                    x.ToTable("EventosUsuarios");
                });

            modelBuilder.Entity<AreaInteresse>()
                .HasMany(c => c.UsuariosInteressados)
                .WithMany(c => c.AreasInteresse)
                .Map(x =>
                {
                    x.MapLeftKey("CodAreaInteresse");
                    x.MapRightKey("EmailUsuario");
                    x.ToTable("InteressesUsuarios");
                });

            modelBuilder.Entity<Feedback>()
                .HasRequired(x => x.Evento)
                .WithMany()
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<AreaInteresse> AreasInteresse { get; set; }
        public virtual DbSet<Atividade> Atividades { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Perfil> Perfis { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Interacao> SalasDiscussoes { get; set; }

    }

}