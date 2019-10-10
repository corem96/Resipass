﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resipass.Data.contexto;

namespace Resipass.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191010051742_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Resipass.Domain.modelos.Aviso.Aviso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comunicado")
                        .HasMaxLength(250);

                    b.Property<DateTime>("FechaPublicacion")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("aviso");
                });

            modelBuilder.Entity("Resipass.Domain.modelos.Domicilio.Domicilio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.HasKey("Id");

                    b.ToTable("domicilio");
                });

            modelBuilder.Entity("Resipass.Domain.modelos.RegistroPago.RegistroPago", b =>
                {
                    b.Property<int>("ResidenteId");

                    b.Property<int>("TarjetaId");

                    b.Property<string>("Cajero")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<DateTime>("FechaPago")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime>("FechaVencimiento")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("DATEADD(month, 1, GETUTCDATE())");

                    b.Property<decimal>("Importe")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(300m);

                    b.Property<string>("NumeroAutorizacion")
                        .IsRequired();

                    b.Property<string>("NumeroFolio")
                        .IsRequired();

                    b.Property<string>("Sucursal")
                        .IsRequired();

                    b.HasKey("ResidenteId", "TarjetaId");

                    b.HasIndex("TarjetaId");

                    b.ToTable("RegistroPagos");
                });

            modelBuilder.Entity("Resipass.Domain.modelos.Residente.Residente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<int>("DomicilioId");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("DomicilioId");

                    b.ToTable("residente");
                });

            modelBuilder.Entity("Resipass.Domain.modelos.Tarjeta.Tarjeta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activa")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int?>("DomicilioId");

                    b.Property<int>("ResidenteId");

                    b.Property<DateTime>("Vigencia");

                    b.HasKey("Id");

                    b.HasIndex("DomicilioId");

                    b.HasIndex("ResidenteId");

                    b.ToTable("tarjeta");
                });

            modelBuilder.Entity("Resipass.Domain.modelos.Usuario.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("Resipass.Domain.modelos.Aviso.Aviso", b =>
                {
                    b.HasOne("Resipass.Domain.modelos.Usuario.Usuario", "Usuario")
                        .WithMany("Avisos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Resipass.Domain.modelos.RegistroPago.RegistroPago", b =>
                {
                    b.HasOne("Resipass.Domain.modelos.Residente.Residente", "Residente")
                        .WithMany("RegistroPagos")
                        .HasForeignKey("ResidenteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Resipass.Domain.modelos.Tarjeta.Tarjeta", "Tarjeta")
                        .WithMany("RegistroPagos")
                        .HasForeignKey("TarjetaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Resipass.Domain.modelos.Residente.Residente", b =>
                {
                    b.HasOne("Resipass.Domain.modelos.Domicilio.Domicilio", "Domicilio")
                        .WithMany("Residentes")
                        .HasForeignKey("DomicilioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Resipass.Domain.modelos.Tarjeta.Tarjeta", b =>
                {
                    b.HasOne("Resipass.Domain.modelos.Domicilio.Domicilio")
                        .WithMany("Tarjetas")
                        .HasForeignKey("DomicilioId");

                    b.HasOne("Resipass.Domain.modelos.Residente.Residente", "Residente")
                        .WithMany("Tarjetas")
                        .HasForeignKey("ResidenteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
