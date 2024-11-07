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
                    }

                );
            }

            //if (!context.User.Any())
            //{ 
            //    context.User.AddRange(

            //        new User
            //        {
            //            Name = "Mohamed",
            //            Email = "mo@gmail.com,",
            //            Password = "Password",
            //        }

            //    );
            //}

            context.SaveChanges();
        }
    }

}