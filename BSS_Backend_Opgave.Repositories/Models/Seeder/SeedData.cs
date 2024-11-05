using BSS_Backend_Opgave.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using BSS_Backend_Opgave.BSS_Backend_Opgave.API.Data;

namespace BSS_Backend_Opgave.Repositories.Models.Seeder;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
         
    }
}


//if (!context.Organisation.Any())
//            {
//                context.Organisation.AddRange(
//                    new Organisation
//                    {
//                        Id = 1,
//                        Name = "FirstOrg",
//                    }
//                );
//            }

//            if (!context.User.Any())
//{
//    context.User.AddRange(
//        new User
//        {
//            Name = "Mohamed",
//            Email = "moh@ucl.dk",
//            Id = 1,
//            OrganisationId = 1,
//        }
//    );
//}