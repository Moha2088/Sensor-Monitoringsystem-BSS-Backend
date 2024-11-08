using BSS_Backend_Opgave.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BSS_Backend_Opgave.Repositories.Data;

namespace BSS_Backend_Opgave.Repositories.Models.Seeder;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BSS_Backend_OpgaveAPIContext(
                   serviceProvider.GetRequiredService<
                       DbContextOptions<BSS_Backend_OpgaveAPIContext>>()))
        {
            if (!context.Organisation.Any())
            {
                context.Organisation.AddRange(

                    new Organisation
                    {
                        Name = "UCL"
                    },

                    new Organisation
                    {
                        Name = "BSS"
                    }

                );
            }

            if (!context.User.Any())
            {
                context.User.AddRange(

                    new User
                    {
                        Name = "Mohamed",
                        Email = "mo@ucl.com,",
                        Password = "Mohamed123",
                    },

                    new User
                    {
                        Name = "Sang",
                        Email = "sn@bss.com",
                        Password = "Sang123"
                    },

                    new User
                    {
                        Name = "Luke",
                        Email = "luke@ucl.com",
                        Password = "Luke123"
                    }

                );
            }

            context.SaveChanges();
        }
    }

}