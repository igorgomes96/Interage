using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InterageApp.Models
{
    public partial class InterageContext : DbContext
    {
        public virtual DbSet<AreaInteresse> AreaInteresse { get; set; }
        public virtual DbSet<Atividade> Atividade { get; set; }
        public virtual DbSet<EnderecoAtividade> EnderecoAtividade { get; set; }
        public virtual DbSet<EnderecoUsuario> EnderecoUsuario { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<ExpositorAtividade> ExpositorAtividade { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<SalaDiscussao> SalaDiscussao { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Credenciais> Credenciais { get; set; }
        public virtual DbSet<UsuarioInteresse> UsuarioInteresse { get; set; }

        public InterageContext() : base()
        {
            //Load references
            /*Atividade
                .Include(x => x.Endereco)
                .Include(x => x.Evento)
                .Load();

            Evento
                .Include(x => x.AreaInteresse)
                .Include(x => x.Usuario)
                .Load();

            ExpositorAtividade
                .Include(x => x.Atividade)
                .Include(x => x.UsuarioExpositor)
                .Load();

            Feedback
                .Include(x => x.Usuario)
                .Include(x => x.Evento)
                .Load();

            SalaDiscussao
                .Include(x => x.Atividade)
                .Include(x => x.UsuarioExpectador)
                .Load();

            Usuario
                .Include(x => x.Perfil)
                .Include(x => x.EnderecoUsuario)
                .Load();

            UsuarioInteresse
                .Include(x => x.AreaInteresse)
                .Include(x => x.Usuario)
                .Load();  */
            

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #pragma warning disable CS1030 // diretiva de #aviso
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-40CKFUQ;Database=Interage;Trusted_Connection=True;user id=usr_interage;password=usr_interage;");
                #pragma warning restore CS1030 // diretiva de #aviso
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AreaInteresse>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo).ValueGeneratedNever();

                entity.Property(e => e.Interesse)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Atividade>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo).ValueGeneratedNever();

                entity.Property(e => e.DescricaoAtividade)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HorarioAtividade).HasColumnType("datetime");

                entity.HasOne(d => d.Evento)
                    .WithMany(p => p.Atividades)
                    .HasForeignKey(d => d.CodEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("atividade_evento_fk");
            });

            modelBuilder.Entity<EnderecoAtividade>(entity =>
            {
                entity.HasKey(e => e.CodigoAtividade);

                entity.Property(e => e.CodigoAtividade).ValueGeneratedNever();

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.CEP)
                    .IsRequired()
                    .HasColumnName("CEP")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UF)
                    .IsRequired()
                    .HasColumnName("UF")
                    .HasColumnType("char(2)");

                entity.HasOne(d => d.Atividade)
                    .WithOne(p => p.EnderecoAtividade)
                    .HasForeignKey<EnderecoAtividade>(d => d.CodigoAtividade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("enderecoatividade_usuario_fk");
            });

            modelBuilder.Entity<EnderecoUsuario>(entity =>
            {
                entity.HasKey(e => e.EmailUsuario);

                entity.Property(e => e.EmailUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.CEP)
                    .IsRequired()
                    .HasColumnName("CEP")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UF)
                    .IsRequired()
                    .HasColumnName("UF")
                    .HasColumnType("char(2)");

                entity.HasOne(d => d.Usuario)
                    .WithOne(p => p.EnderecoUsuario)
                    .HasForeignKey<EnderecoUsuario>(d => d.EmailUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("enderecousuario_usuario_fk");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo).ValueGeneratedNever();

                entity.Property(e => e.DataFim).HasColumnType("datetime");

                entity.Property(e => e.DataInicio).HasColumnType("datetime");

                entity.Property(e => e.EmailUsuarioPromotor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocalizacaoLatitude).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.LocalizacaoLogitude).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Nome)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.AreaInteresse)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.CodAreaInteresse)
                    .HasConstraintName("evento_areainteress_fk");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.EmailUsuarioPromotor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("evento_usuario_fk");
            });

            modelBuilder.Entity<ExpositorAtividade>(entity =>
            {
                entity.HasKey(e => new { e.CodAtividade, e.EmailUsuarioExpositor });

                entity.Property(e => e.EmailUsuarioExpositor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Atividade)
                    .WithMany(p => p.ExpositoresAtividade)
                    .HasForeignKey(d => d.CodAtividade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("expositoratividade_atividade_fk");

                entity.HasOne(d => d.UsuarioExpositor)
                    .WithMany(p => p.ExpositoresAtividade)
                    .HasForeignKey(d => d.EmailUsuarioExpositor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("expositoratividade_usuario_fk");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.EmailUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MensagemFeedback)
                    .IsRequired()
                    .HasColumnName("Feedback")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TipoFeedback)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Evento)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CodEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("feedback_evento_fk");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.EmailUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("feedback_usuario_fk");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.HasIndex(e => e.NomePerfil)
                    .HasName("nomeperfil_unq")
                    .IsUnique();

                entity.Property(e => e.Codigo).ValueGeneratedNever();

                entity.Property(e => e.NomePerfil)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SalaDiscussao>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo).ValueGeneratedNever();

                entity.Property(e => e.EmailUsuarioExpectador)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Atividade)
                    .WithMany(p => p.SalasDiscussoes)
                    .HasForeignKey(d => d.CodAtividade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("saladiscussao_atividade_fk");

                entity.HasOne(d => d.UsuarioExpectador)
                    .WithMany(p => p.SalasDiscussao)
                    .HasForeignKey(d => d.EmailUsuarioExpectador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("saladiscussao_usuario_fk");
            });


            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CPF)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasColumnType("char(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.CodigoPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuario_perfil_fk");

                entity.HasOne(u => u.Credenciais);
            });

            modelBuilder.Entity<Credenciais>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<UsuarioInteresse>(entity =>
            {
                entity.HasKey(e => new { e.CodInteresse, e.EmailUsuario });

                entity.Property(e => e.EmailUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AreaInteresse)
                    .WithMany(p => p.UsuariosInteresses)
                    .HasForeignKey(d => d.CodInteresse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuariointeresse_areainteresse_fk");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.UsuariosInteresses)
                    .HasForeignKey(d => d.EmailUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuario_interesse_usuario_fk");
            });
        }
    }
}
