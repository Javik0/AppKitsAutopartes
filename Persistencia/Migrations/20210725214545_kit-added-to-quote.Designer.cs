﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

namespace Persistencia.Migrations
{
    [DbContext(typeof(QuoteContext))]
    [Migration("20210725214545_kit-added-to-quote")]
    partial class kitaddedtoquote
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Modelos.Quote.AltParte", b =>
                {
                    b.Property<int>("ParteId")
                        .HasColumnType("int");

                    b.Property<int>("ParteAlternaId")
                        .HasColumnType("int");

                    b.HasKey("ParteId", "ParteAlternaId");

                    b.HasIndex("ParteAlternaId");

                    b.ToTable("altPartes");
                });

            modelBuilder.Entity("Modelos.Quote.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("Modelos.Quote.Estado", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EstadoValor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoId");

                    b.ToTable("estados");
                });

            modelBuilder.Entity("Modelos.Quote.Kit", b =>
                {
                    b.Property<int>("KitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KitId");

                    b.ToTable("kits");
                });

            modelBuilder.Entity("Modelos.Quote.KitPart", b =>
                {
                    b.Property<int>("KitId")
                        .HasColumnType("int");

                    b.Property<int>("ParteId")
                        .HasColumnType("int");

                    b.HasKey("KitId", "ParteId");

                    b.HasIndex("ParteId");

                    b.ToTable("kitParts");
                });

            modelBuilder.Entity("Modelos.Quote.Parte", b =>
                {
                    b.Property<int>("ParteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ParteId");

                    b.ToTable("partes");
                });

            modelBuilder.Entity("Modelos.Quote.Quote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("KitId")
                        .HasColumnType("int");

                    b.HasKey("QuoteId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("KitId");

                    b.ToTable("quotes");
                });

            modelBuilder.Entity("Modelos.Quote.QuotePart", b =>
                {
                    b.Property<int>("QuotePartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AltParteId")
                        .HasColumnType("int");

                    b.Property<bool?>("AltParteStock")
                        .HasColumnType("bit");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ParteId")
                        .HasColumnType("int");

                    b.Property<int>("QuoteId")
                        .HasColumnType("int");

                    b.Property<bool>("Stock")
                        .HasColumnType("bit");

                    b.HasKey("QuotePartId");

                    b.HasIndex("AltParteId");

                    b.HasIndex("ParteId");

                    b.HasIndex("QuoteId");

                    b.ToTable("quoteParts");
                });

            modelBuilder.Entity("Modelos.Quote.AltParte", b =>
                {
                    b.HasOne("Modelos.Quote.Parte", "ParteAlterna")
                        .WithMany()
                        .HasForeignKey("ParteAlternaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelos.Quote.Parte", "Parte")
                        .WithMany("altPartes")
                        .HasForeignKey("ParteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Parte");

                    b.Navigation("ParteAlterna");
                });

            modelBuilder.Entity("Modelos.Quote.KitPart", b =>
                {
                    b.HasOne("Modelos.Quote.Kit", "Kit")
                        .WithMany("KitParts")
                        .HasForeignKey("KitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelos.Quote.Parte", "Parte")
                        .WithMany()
                        .HasForeignKey("ParteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kit");

                    b.Navigation("Parte");
                });

            modelBuilder.Entity("Modelos.Quote.Quote", b =>
                {
                    b.HasOne("Modelos.Quote.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelos.Quote.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelos.Quote.Kit", "kit")
                        .WithMany()
                        .HasForeignKey("KitId");

                    b.Navigation("Cliente");

                    b.Navigation("Estado");

                    b.Navigation("kit");
                });

            modelBuilder.Entity("Modelos.Quote.QuotePart", b =>
                {
                    b.HasOne("Modelos.Quote.Parte", "AltParte")
                        .WithMany()
                        .HasForeignKey("AltParteId");

                    b.HasOne("Modelos.Quote.Parte", "Parte")
                        .WithMany()
                        .HasForeignKey("ParteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelos.Quote.Quote", "Quote")
                        .WithMany("QuoteParts")
                        .HasForeignKey("QuoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AltParte");

                    b.Navigation("Parte");

                    b.Navigation("Quote");
                });

            modelBuilder.Entity("Modelos.Quote.Kit", b =>
                {
                    b.Navigation("KitParts");
                });

            modelBuilder.Entity("Modelos.Quote.Parte", b =>
                {
                    b.Navigation("altPartes");
                });

            modelBuilder.Entity("Modelos.Quote.Quote", b =>
                {
                    b.Navigation("QuoteParts");
                });
#pragma warning restore 612, 618
        }
    }
}
