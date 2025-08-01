﻿// <auto-generated />
using System;
using CityBreaks.Agency.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CityBreaks.Agency.Migrations
{
    [DbContext(typeof(CityBreakAgencyContext))]
    [Migration("20250615030831_DefineRelationships")]
    partial class DefineRelationships
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.6");

            modelBuilder.Entity("CidadeDestinoPacoteTuristico", b =>
                {
                    b.Property<int>("DestinosId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PacotesTuristicosId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DestinosId", "PacotesTuristicosId");

                    b.HasIndex("PacotesTuristicosId");

                    b.ToTable("CidadeDestinoPacoteTuristico");
                });

            modelBuilder.Entity("CityBreaks.Agency.Models.CidadeDestino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("PaisDestinoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PaisDestinoId");

                    b.ToTable("CidadesDestino");
                });

            modelBuilder.Entity("CityBreaks.Agency.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("CityBreaks.Agency.Models.PacoteTuristico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CapacidadeMaxima")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Preco")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PacotesTuristicos");
                });

            modelBuilder.Entity("CityBreaks.Agency.Models.PaisDestino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PaisesDestino");
                });

            modelBuilder.Entity("CityBreaks.Agency.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataReserva")
                        .HasColumnType("TEXT");

                    b.Property<int>("PacoteTuristicoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PacoteTuristicoId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("CidadeDestinoPacoteTuristico", b =>
                {
                    b.HasOne("CityBreaks.Agency.Models.CidadeDestino", null)
                        .WithMany()
                        .HasForeignKey("DestinosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CityBreaks.Agency.Models.PacoteTuristico", null)
                        .WithMany()
                        .HasForeignKey("PacotesTuristicosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CityBreaks.Agency.Models.CidadeDestino", b =>
                {
                    b.HasOne("CityBreaks.Agency.Models.PaisDestino", "Pais")
                        .WithMany("Cidades")
                        .HasForeignKey("PaisDestinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("CityBreaks.Agency.Models.Reserva", b =>
                {
                    b.HasOne("CityBreaks.Agency.Models.Cliente", "Cliente")
                        .WithMany("Reservas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CityBreaks.Agency.Models.PacoteTuristico", "PacoteTuristico")
                        .WithMany("Reservas")
                        .HasForeignKey("PacoteTuristicoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("PacoteTuristico");
                });

            modelBuilder.Entity("CityBreaks.Agency.Models.Cliente", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("CityBreaks.Agency.Models.PacoteTuristico", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("CityBreaks.Agency.Models.PaisDestino", b =>
                {
                    b.Navigation("Cidades");
                });
#pragma warning restore 612, 618
        }
    }
}
