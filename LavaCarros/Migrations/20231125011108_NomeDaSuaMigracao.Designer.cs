﻿// <auto-generated />
using System;
using LavaCarros.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LavaCarros.Migrations
{
    [DbContext(typeof(CarroContext))]
    [Migration("20231125011108_NomeDaSuaMigracao")]
    partial class NomeDaSuaMigracao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Carro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Dono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("TipoLavagemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoLavagemId");

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("ServicoLavagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("ServicosLavagem");
                });

            modelBuilder.Entity("Carro", b =>
                {
                    b.HasOne("ServicoLavagem", "TipoLavagem")
                        .WithMany()
                        .HasForeignKey("TipoLavagemId");

                    b.Navigation("TipoLavagem");
                });
#pragma warning restore 612, 618
        }
    }
}
