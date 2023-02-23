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
        public DbSet<Verb> Verbs { get; set; }
        public DbSet<Description> Descriptions { get; set; }

        public EnglishTrainerContext(DbContextOptions<EnglishTrainerContext> options) : base(options) { }
    }
}
