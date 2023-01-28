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
                new ("bet", "bet", "bet", "держать пари"),
                new ("bite", "bit", "bitten", "кусать"),
                new ("blow", "blew", "blown", "дуть, выдыхать"),
                new ("break", "broke", "broken", "ломать, разбивать, разрушать"),
                new ("bring", "brought", "brought", "приносить, привозить, доставлять"),
                new ("build", "build", "build", "строить, сооружать"),
                new ("buy", "bought", "bought", "покупать, приобретать"),
                new ("catch", "caught", "caught", "ловить, поймать, схватить"),
                new ("choose", "chose", "chosen", "выбирать, избирать"),
                new ("come", "came", "come", "приходить, подходить"),
                new ("cost", "cost", "cost", "стоить, обходиться"),
                new ("cut", "cut", "cut", "резать, разрезать"),
                new ("deal", "dealt", "dealt", "иметь дело, распределять"),
                new ("dig", "dug", "dug", "копать, рыть"),
                new ("do", "did", "done", "делать, выполнять"),
                new ("draw", "drew", "drawn", "рисовать, чертить"),
                new ("drink", "drank", "drunk", "пить"),
                new ("drive", "drove", "driven", "ездить, подвозить"),
                new ("eat", "ate", "eaten", "есть, поглощать, поедать"),
                new ("fall", "fell", "fallen", "падать"),
                new ("feed", "fed", "fed", "кормить"),
                new ("feel", "felt", "felt", "чувствовать, ощущать"),
                new ("fight", "fought", "fought", "драться, сражаться, воевать"),
                new ("find", "found", "found", "находить, обнаруживать"),
                new ("fly", "flew", "flown", "летать"),
                new ("forget", "forgot", "forgotten", "забывать о (чём-либо)"),
                new ("forgive", "forgave", "forgiven", "прощать"),
                new ("freeze", "froze", "frozen", "замерзать, замирать"),
                new ("get", "got", "got", "получать, добираться"),
                new ("give", "gave", "given", "дать, подать, дарить"),
                new ("go", "went", "gone", "идти, двигаться"),
                new ("grow", "grew", "grown", "расти, вырастать"),
                new ("hang", "hung", "hung", "вешать, развешивать, висеть"),
                new ("have", "had", "had", "иметь, обладать"),
                new ("hear", "heard", "heard", "слышать, услышать"),
                new ("hide", "hid", "hidden", "прятать, скрывать"),
                new ("hit", "hit", "hit", "ударять, поражать"),
                new ("hold", "held", "held", "держать, удерживать, задерживать"),
                new ("hurt", "hurt", "hurt", "ранить, причинять боль, ушибить"),
                new ("keep", "kept", "kept", "хранить, сохранять, поддерживать"),
                new ("know", "knew", "known", "знать, иметь представление"),
                new ("lay", "laid", "laid", "класть, положить, покрывать"),
                new ("lead", "led", "led", "вести за собой, сопровождать, руководить"),
                new ("leave", "left", "left", "покидать, уходить, уезжать, оставлять"),
                new ("lend", "lent", "lent", "одалживать, давать взаймы (в долг)"),
                new ("let", "let", "let", "позволять, разрешать"),
                new ("lie", "lay", "lain", "лежать"),
                new ("light", "lit", "lit", "зажигать, светиться, освещать"),
                new ("lose", "lost", "lost", "терять, лишаться, утрачивать"),
                new ("make", "made", "made", "делать, создавать, изготавливать"),
                new ("mean", "meant", "meant", "значить, иметь в виду, подразумевать"),
                new ("meet", "met", "met", "встречать, знакомиться"),
                new ("pay", "paid", "paid", "платить, оплачивать, рассчитываться"),
                new ("put", "put", "put", "платить, оплачивать, рассчитываться"),
                new ("read", "read", "read", "читать, прочитать"),
                new ("ride", "rode", "ridden", "ехать верхом, кататься"),
                new ("ring", "rang", "rung", "звенеть, звонить"),
                new ("rise", "rose", "risen", "восходить, вставать, подниматься"),
                new ("run", "ran", "run", "бежать, бегать"),
                new ("say", "said", "said", "говорить, сказать, произносить"),
                new ("see", "saw", "seen", "видеть"),
                new ("seek", "sought", "sought", "искать, разыскивать"),
                new ("sell", "sold", "sold", "продавать, торговать"),
                new ("send", "sent", "sent", "посылать, отправлять, отсылать"),
                new ("set", "set", "set", "устанавливать, задавать, назначать"),
                new ("shake", "shook", "shaken", "трясти, встряхивать"),
                new ("shine", "shone", "shone", "светить, сиять, озарять"),
                new ("shoot", "shot", "shot", "стрелять"),
                new ("show", "showed", "shown/showed", "стрелять"),
                new ("shut", "shut", "shut", "закрывать, запирать, затворять"),
                new ("sing", "sang", "sung", "петь, напевать"),
                new ("sink", "sank", "sunk", "тонуть, погружаться"),
                new ("sit", "sat", "sat", "сидеть, садиться"),
                new ("sleep", "slept", "slept", "спать"),
                new ("speak", "spoke", "spoken", "говорить, разговаривать, высказываться"),
                new ("spend", "spent", "spent", "тратить, расходовать, проводить (время)"),
                new ("stand", "stood", "stood", "стоять"),
                new ("steal", "stole", "stolen", "воровать, красть"),
                new ("stick", "stuck", "stuck", "втыкать, приклеивать"),
                new ("strike", "struck", "struck/stricken", "ударять, бить, поражать"),
                new ("swear", "swore", "sworn", "клясться, присягать"),
                new ("sweep", "swept", "swept", "мести, подметать, смахивать"),
                new ("swim", "swam", "swum", "плавать, плыть"),
                new ("swing", "swung", "swung", "качаться, вертеться"),
                new ("take", "took", "taken", "брать, хватать, взять"),
                new ("teach", "taught", "taught", "учить, обучать"),
                new ("tear", "tore", "torn", "рвать, отрывать"),
                new ("tell", "told", "told", "рассказывать"),
                new ("think", "thought", "thought", "думать, мыслить, размышлять"),
                new ("throw", "threw", "thrown", "бросать, кидать, метать"),
                new ("understand", "understood", "understood", "понимать, постигать"),
                new ("wake", "woke", "woken", "просыпаться, будить"),
                new ("wear", "wore", "worn", "носить (одежду)"),
                new ("win", "won", "won", "победить, выиграть"),
                new ("write", "wrote", "written", "писать, записывать"),
            };   
        }

    }
}
