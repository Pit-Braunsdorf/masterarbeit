using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Masterarbeit.DatabaseService.Database.Model;
using Microsoft.Extensions.Configuration;

namespace Masterarbeit.DatabaseService.Database.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();

            if (context.FixedWords.Any())
            {
                return; //DB has been seeded
            }

            var fixedWords = new FixedWord[]
            {
                new FixedWord {Word = "Test", Language = "de-DE", Inserted = DateTime.Today, Updated = null},
            };

            foreach (var f in fixedWords)
            {
                context.FixedWords.Add(f);
            }

            context.SaveChanges();
        }
    }
}
