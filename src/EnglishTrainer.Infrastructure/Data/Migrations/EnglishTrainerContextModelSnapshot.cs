﻿// <auto-generated />
using System;
using EnglishTrainer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EnglishTrainer.Infrastructure.Data.Migrations
{
    [DbContext(typeof(EnglishTrainerContext))]
    partial class EnglishTrainerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EnglishTrainer.ApplicationCore.Entities.Description", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AllTranslateVariants")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Descriptions");
                });

            modelBuilder.Entity("EnglishTrainer.ApplicationCore.Entities.Example", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DescriptionId")
                        .HasColumnType("int");

                    b.Property<string>("EnglishExample")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RussianExample")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DescriptionId");

                    b.ToTable("Example");
                });

            modelBuilder.Entity("EnglishTrainer.ApplicationCore.Entities.Verb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DescriptionId")
                        .HasColumnType("int");

                    b.Property<string>("Infinitive")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PastParticiple")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PastSimple")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortTranslate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DescriptionId");

                    b.ToTable("Verbs");
                });

            modelBuilder.Entity("EnglishTrainer.ApplicationCore.Entities.Example", b =>
                {
                    b.HasOne("EnglishTrainer.ApplicationCore.Entities.Description", "Description")
                        .WithMany("Examples")
                        .HasForeignKey("DescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Description");
                });

            modelBuilder.Entity("EnglishTrainer.ApplicationCore.Entities.Verb", b =>
                {
                    b.HasOne("EnglishTrainer.ApplicationCore.Entities.Description", "Description")
                        .WithMany()
                        .HasForeignKey("DescriptionId");

                    b.Navigation("Description");
                });

            modelBuilder.Entity("EnglishTrainer.ApplicationCore.Entities.Description", b =>
                {
                    b.Navigation("Examples");
                });
#pragma warning restore 612, 618
        }
    }
}
