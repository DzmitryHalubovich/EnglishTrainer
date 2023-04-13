﻿// <auto-generated />
using System;
using EnglishTrainer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EnglishTrainer.Infrastructure.Migrations
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

            modelBuilder.Entity("EnglishTrainer.ApplicationCore.Entities.Example", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EnglishExample")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("engliish_example");

                    b.Property<string>("RussianExample")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("russian_translate");

                    b.Property<int>("WordId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WordId");

                    b.ToTable("examples");
                });

            modelBuilder.Entity("EnglishTrainer.ApplicationCore.Entities.IrregularVerb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Infinitive")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("infinitive");

                    b.Property<string>("PastParticiple")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("past_participle");

                    b.Property<string>("PastSimple")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("past_simple");

                    b.Property<string>("ShortTranslate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("short_translate");

                    b.HasKey("Id");

                    b.ToTable("irregular_verbs");
                });

            modelBuilder.Entity("EnglishTrainer.ApplicationCore.Entities.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("EnglishTrainer.ApplicationCore.Entities.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("EnglishTrainer.ApplicationCore.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EnglishTrainer.ApplicationCore.Entities.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("date")
                        .HasColumnName("created");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("word");

                    b.Property<string>("TranslateVariants")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("translate");

                    b.HasKey("Id");

                    b.ToTable("dictionary", (string)null);
                });

            modelBuilder.Entity("EnglishTrainer.ApplicationCore.Entities.Example", b =>
                {
                    b.HasOne("EnglishTrainer.ApplicationCore.Entities.Word", "Word")
                        .WithMany("Examples")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Word");
                });

            modelBuilder.Entity("EnglishTrainer.ApplicationCore.Entities.Profile", b =>
                {
                    b.HasOne("EnglishTrainer.ApplicationCore.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EnglishTrainer.ApplicationCore.Entities.Word", b =>
                {
                    b.Navigation("Examples");
                });
#pragma warning restore 612, 618
        }
    }
}
