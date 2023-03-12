using EnglishTrainer.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.Infrastructure.Data
{
    public sealed class EnglishTrainerContext : DbContext
    {
        public DbSet<IrregularVerb> Verbs { get; set; }
        public DbSet<Example> Examples { get; set; }
        public DbSet<Word> Words { get; set; }

        public EnglishTrainerContext(DbContextOptions<EnglishTrainerContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>(builder =>
            {
                builder.Property(x=>x.Id).ValueGeneratedOnAdd();
                builder.Property(x=>x.Name).HasColumnName("word").HasColumnType("nvarchar(max)").IsRequired();
                builder.Property(x => x.TranslateVariants).HasColumnName("translate").HasColumnType("nvarchar(max)").IsRequired();
                builder.Property(x => x.Created).HasColumnName("created").HasColumnType("date");
                builder.HasMany(x => x.Examples).WithOne(e=>e.Word);
                builder.ToTable("dictionary");
            });
        }
    }
}
