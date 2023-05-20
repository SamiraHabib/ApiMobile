﻿// <auto-generated />
using ApiMobile.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMobile.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20230520021209_CriacaoDeTabelaDeRotina")]
    partial class CriacaoDeTabelaDeRotina
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiMobile.Models.Conteudo", b =>
                {
                    b.Property<int>("IdConteudo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdConteudo"));

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdMedico")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoLesao")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subtitulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdConteudo");

                    b.HasIndex("IdMedico");

                    b.HasIndex("IdTipoLesao");

                    b.ToTable("conteudo", (string)null);
                });

            modelBuilder.Entity("ApiMobile.Models.DiaSemana", b =>
                {
                    b.Property<int>("IdDiaSemana")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDiaSemana"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDiaSemana");

                    b.ToTable("dia_semana", (string)null);
                });

            modelBuilder.Entity("ApiMobile.Models.Exercicio", b =>
                {
                    b.Property<int>("IdExercicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdExercicio"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("EncodedGif")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("IdMedico")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoLesao")
                        .HasColumnType("int");

                    b.Property<string>("Instrucoes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacoes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Precaucoes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdExercicio");

                    b.HasIndex("IdMedico");

                    b.HasIndex("IdTipoLesao");

                    b.ToTable("exercicio", (string)null);
                });

            modelBuilder.Entity("ApiMobile.Models.Medico", b =>
                {
                    b.Property<int>("IdMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedico"));

                    b.Property<string>("NumeroCrm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SituacaoCrm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UfCrm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMedico");

                    b.ToTable("medico", (string)null);
                });

            modelBuilder.Entity("ApiMobile.Models.Paciente", b =>
                {
                    b.Property<int>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPaciente"));

                    b.Property<string>("Ocupacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPaciente");

                    b.ToTable("paciente", (string)null);
                });

            modelBuilder.Entity("ApiMobile.Models.Rotina", b =>
                {
                    b.Property<int>("IdRotina")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRotina"));

                    b.Property<bool?>("Ativa")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("HorarioFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("HorarioInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("int");

                    b.Property<int?>("Intervalo")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRotina");

                    b.HasIndex("IdPaciente");

                    b.ToTable("rotina", (string)null);
                });

            modelBuilder.Entity("ApiMobile.Models.TipoLesao", b =>
                {
                    b.Property<int>("IdTipoLesao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoLesao"));

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdMedico")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sigla")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoLesao");

                    b.HasIndex("IdMedico");

                    b.ToTable("tipo_lesao", (string)null);
                });

            modelBuilder.Entity("ApiMobile.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("IdMedico")
                        .HasColumnType("int");

                    b.Property<int?>("IdPaciente")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenhaEncriptada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("IdMedico");

                    b.HasIndex("IdPaciente");

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("ApiMobile.Models.Conteudo", b =>
                {
                    b.HasOne("ApiMobile.Models.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApiMobile.Models.TipoLesao", "TipoLesao")
                        .WithMany()
                        .HasForeignKey("IdTipoLesao")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("TipoLesao");
                });

            modelBuilder.Entity("ApiMobile.Models.Exercicio", b =>
                {
                    b.HasOne("ApiMobile.Models.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApiMobile.Models.TipoLesao", "TipoLesao")
                        .WithMany()
                        .HasForeignKey("IdTipoLesao")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("TipoLesao");
                });

            modelBuilder.Entity("ApiMobile.Models.Rotina", b =>
                {
                    b.HasOne("ApiMobile.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("ApiMobile.Models.TipoLesao", b =>
                {
                    b.HasOne("ApiMobile.Models.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("ApiMobile.Models.Usuario", b =>
                {
                    b.HasOne("ApiMobile.Models.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ApiMobile.Models.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });
#pragma warning restore 612, 618
        }
    }
}
