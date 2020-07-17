using FarQ_Backend_1.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Q_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarQ_Backend_1.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FarQContext(
                serviceProvider.GetRequiredService<DbContextOptions<FarQContext>>()))
            {
                // Look for any movies.
                if (context.User.Count() > 0)
                {
                    return;   // DB has been seeded
                }

                context.User.AddRange(
                    new User
                    {
                        Name = "David",
                        EventID = 0,
                        Email = "test@test.com"
                    }
                );
                //context.Event.AddRange(
                //    new Event
                //    {
                //        Description = "test",
                //        EmployerLink = "fdsjfldks",
                //        EventID = 1,
                //        HelpLink = "s",
                //        Name = "dsa",
                //        Status = "dsad",
                //        UserLink = "dsads"
                //    }
                //);
                context.SaveChanges();
            }
        }
    }
}