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

           context.SaveChanges();
        }
    }
}
