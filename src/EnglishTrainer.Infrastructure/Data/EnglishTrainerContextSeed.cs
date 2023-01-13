using EnglishTrainer.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.Infrastructure.Data
{
    public class EnglishTrainerContextSeed
    {
        public static async Task SeedAsync(EnglishTrainerContext context, ILogger logger, int retry =0)
        {
            var retryForAvailability = retry;

            try
            {
                if (!await context.Verbs.AnyAsync())
                {
                    await context.AddRangeAsync(GetPreconfiguredVerbs());

                    await context.SaveChangesAsync();
                }

                //TODO the same for another entities

            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 10) throw;

                retryForAvailability++;

                logger.LogError(ex.Message);
                await SeedAsync(context, logger, retryForAvailability);
            }
        }

        private static IEnumerable<Verb> GetPreconfiguredVerbs()
        {
            return new List<Verb>
            {
                new ("be", "was/were", "been", "быть/являться"),
                new ("beat", "beat", "beaten", "бить/колотить"),
                new ("become", "became", "become", "становиться"),
                new ("begin", "began", "begun", "начинать"),
                new ("bend", "bent", "bent", "гнуть"),
            };   
        }

    }
}
