﻿// <auto-generated />
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

            modelBuilder.Entity("EnglishTrainer.ApplicationCore.Entities.TranslateByPartsOfSpeech", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adjective")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("adjective");

                    b.Property<string>("Adverb")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("adverb");

                    b.Property<string>("Conjunction")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("conjunction");

                    b.Property<string>("Interjection")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("interjection");

                    b.Property<string>("Noun")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("noun");

                    b.Property<string>("Preposition")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("preposition");

                    b.Property<string>("Pronoun")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("pronoun");

                    b.Property<string>("Verb")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("verb");

                    b.Property<int>("WordId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WordId")
                        .IsUnique();

                    b.ToTable("various_translations");
                });

            modelBuilder.Entity("EnglishTrainer.ApplicationCore.Entities.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .HasColumnName("word");

                    b.Property<string>("TranslateVariants")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
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

            modelBuilder.Entity("EnglishTrainer.ApplicationCore.Entities.TranslateByPartsOfSpeech", b =>
                {
                    b.HasOne("EnglishTrainer.ApplicationCore.Entities.Word", "Word")
                        .WithOne("PartsOfSpeech")
                        .HasForeignKey("EnglishTrainer.ApplicationCore.Entities.TranslateByPartsOfSpeech", "WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Word");
                });

            modelBuilder.Entity("EnglishTrainer.ApplicationCore.Entities.Word", b =>
                {
                    b.Navigation("Examples");

                    b.Navigation("PartsOfSpeech")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
