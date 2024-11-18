using BSS_Backend_Opgave.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BSS_Backend_Opgave.Repositories.Data;

namespace BSS_Backend_Opgave.Repositories.Models.Seeder;

public class SeedData
{
    public static async void Initialize(IServiceProvider serviceProvider)
    {

        using (var context = new BSS_Backend_OpgaveAPIContext(
                   serviceProvider.GetRequiredService<
                       DbContextOptions<BSS_Backend_OpgaveAPIContext>>()))
        {

            if (!context.SensorCategory.Any())
            {
                context.AddRange(

                    new SensorCategory
                    {
                        Name = "School"
                    },

                    new SensorCategory
                    {
                        Name = "Military"
                    }
                );
            }

            if (!context.Organisation.Any())
            {
                context.Organisation.AddRange(

                    new Organisation
                    {
                        Name = "UCL",
                        Users = new List<User> 
                        {
                            new User
                            {
                                Name = "Mohamed",
                                Email = "mo@ucl.com",
                                Password = "Mohac123",
                            },

                            new User
                            {
                                Name = "Luke",
                                Email = "luke@ucl.com",
                                Password = "Luke123",
                            },

                            new User
                            {
                                Name = "Test",
                                Email = "Test@test.com",
                                Password = "Test"
                            }
                        },
                        
                        Sensors = new List<Sensor>
                        {
                            new Sensor
                            {
                                Name = "UCL Sensor1",
                                Location = "Seebladsgade 1, Odense 5000 C"
                            },
                            
                            new Sensor
                            {
                                Name = "UCL Sensor2",
                                Location = "Niels Bohrs Alle 1 5230 Odense M"
                            }
                        }
                    },

                    new Organisation
                    {
                        Name = "BSS",
                        Users = new List<User>
                        {
                            new User
                            {
                                Name = "Mads",
                                Email = "mh@bss.com",
                                Password = "Mads123",
                            },

                            new User
                            {
                                Name = "Nikolaj",
                                Email = "nh@bss.com",
                                Password = "Nikolaj123",
                            },

                            new User
                            {
                                Name = "Test",
                                Email = "Test@test1.com",
                                Password = "Test"
                            }
                        },
                        
                        Sensors = new List<Sensor>
                        {
                            new Sensor
                            {
                                Name = "BSS Sensor1",
                                Location = "Østre Stationsvej 5000 Odense C"
                            },
                            
                            new Sensor
                            {
                                Name = "BSS Sensor2",
                                Location = "Fjordsgade 11"
                            }
                        }
                    }
                );
            }

            context.SaveChanges();
        }
    }

}