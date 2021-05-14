﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using todoAPI.Data;

namespace todoAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("todoAPI.Models.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Completado")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Prazo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Prioridade")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ToDos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Completado = false,
                            Descricao = "Analisar Requisitos",
                            Prazo = new DateTime(2021, 5, 13, 17, 21, 34, 296, DateTimeKind.Local).AddTicks(5407),
                            Prioridade = "Alta"
                        },
                        new
                        {
                            Id = 2,
                            Completado = false,
                            Descricao = "Criar o Model",
                            Prazo = new DateTime(2021, 5, 13, 17, 21, 34, 297, DateTimeKind.Local).AddTicks(8723),
                            Prioridade = "Alta"
                        },
                        new
                        {
                            Id = 3,
                            Completado = false,
                            Descricao = "Criar e implementar o Controller",
                            Prazo = new DateTime(2021, 5, 13, 17, 21, 34, 297, DateTimeKind.Local).AddTicks(8832),
                            Prioridade = "Alta"
                        },
                        new
                        {
                            Id = 4,
                            Completado = false,
                            Descricao = "Criar a Interface Front End em Angular",
                            Prazo = new DateTime(2021, 5, 13, 17, 21, 34, 297, DateTimeKind.Local).AddTicks(8836),
                            Prioridade = "Alta"
                        },
                        new
                        {
                            Id = 5,
                            Completado = false,
                            Descricao = "Terminar e Testar a Aplicação",
                            Prazo = new DateTime(2021, 5, 13, 17, 21, 34, 297, DateTimeKind.Local).AddTicks(8838),
                            Prioridade = "Alta"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
