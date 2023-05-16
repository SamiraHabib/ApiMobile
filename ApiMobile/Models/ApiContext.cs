using Microsoft.EntityFrameworkCore;

namespace ApiMobile.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<TipoLesao> TiposLesao { get; set; }
        public DbSet<Conteudo> Conteudos { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<DiaSemana> DiasSemana { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().ToTable("usuario").HasKey(u => u.IdUsuario);
            modelBuilder.Entity<Medico>().ToTable("medico").HasKey(m => m.IdMedico);
            modelBuilder.Entity<Paciente>().ToTable("paciente").HasKey(p => p.IdPaciente);
            modelBuilder.Entity<TipoLesao>().ToTable("tipo_lesao").HasKey(tl => tl.IdTipoLesao);
            modelBuilder.Entity<Conteudo>().ToTable("conteudo").HasKey(c => c.IdConteudo);
            modelBuilder.Entity<Exercicio>().ToTable("exercicio").HasKey(e => e.IdExercicio);
            modelBuilder.Entity<DiaSemana>().ToTable("dia_semana").HasKey(ds => ds.IdDiaSemana);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Paciente)
                .WithMany()
                .HasForeignKey(u => u.IdPaciente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Medico)
                .WithMany()
                .HasForeignKey(u => u.IdMedico)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TipoLesao>()
                .HasOne(t => t.Medico)
                .WithMany()
                .HasForeignKey(t => t.IdMedico)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Conteudo>()
                .HasOne(c => c.Medico)
                .WithMany()
                .HasForeignKey(c => c.IdMedico)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Conteudo>()
                .HasOne(c => c.TipoLesao)
                .WithMany()
                .HasForeignKey(c => c.IdTipoLesao)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Exercicio>()
                .HasOne(e => e.Medico)
                .WithMany()
                .HasForeignKey(e => e.IdMedico)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Exercicio>()
                .HasOne(e => e.TipoLesao)
                .WithMany()
                .HasForeignKey(e => e.IdTipoLesao)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DiaSemana>().HasData(
              new DiaSemana { IdDiaSemana = 1, Nome = "Domingo" },
              new DiaSemana { IdDiaSemana = 2, Nome = "Segunda-feira" }, 
              new DiaSemana { IdDiaSemana = 3, Nome = "Terça-feira" }, 
              new DiaSemana { IdDiaSemana = 4, Nome = "Quarta-feira" }, 
              new DiaSemana { IdDiaSemana = 5, Nome = "Quinta-feira" }, 
              new DiaSemana { IdDiaSemana = 6, Nome = "Sexta-feira" }, 
              new DiaSemana { IdDiaSemana = 7, Nome = "Sábado" }
            );
        }
    }
}