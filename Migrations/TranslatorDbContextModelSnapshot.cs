﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TranslatorApp.DataAccessLayer.TranslatorDbContext;

#nullable disable

namespace TranslatorApp.Migrations
{
    [DbContext(typeof(TranslateDbContext))]
    partial class TranslatorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TranslatorApp.Entities.Word", b =>
                {
                    b.Property<int>("WordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("WordId"));

                    b.Property<string>("Azerbaycanca")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Ozbekce")
                        .HasColumnType("text");

                    b.Property<string>("Qazaxca")
                        .HasColumnType("text");

                    b.Property<string>("Qirgizca")
                        .HasColumnType("text");

                    b.Property<string>("Tatarca")
                        .HasColumnType("text");

                    b.Property<string>("Turkce")
                        .HasColumnType("text");

                    b.Property<string>("Turkmence")
                        .HasColumnType("text");

                    b.Property<string>("UnSelected")
                        .HasColumnType("text");

                    b.Property<string>("Uygurca")
                        .HasColumnType("text");

                    b.HasKey("WordId");

                    b.HasIndex("Azerbaycanca")
                        .IsUnique();

                    b.ToTable("Words");
                });
#pragma warning restore 612, 618
        }
    }
}