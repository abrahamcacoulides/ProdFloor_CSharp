using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ProdFloor.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
            .GetRequiredService<ApplicationDbContext>();
            //context.Database.Migrate();
            if (!context.Jobs.Any())
            {
                context.Jobs.AddRange(
                    new Job
                    {
                        Name = "BRENTWOOD CONDOS",
                        JobNum = 2017088571,
                        PO = 3398238,
                        Cust = "OTIS-MP",
                        JobState = "Texas",
                        SafetyCode = "ASME A17.1-2007/CSA B44-07",
                        JobType = "M2000",
                        ShipDate = new DateTime(2017,12,28)
                    },
                    new Job
                    {
                        Name = "Job Name 2",
                        JobNum = 2017088362,
                        PO = 3398175,
                        Cust = "FAKE-2",
                        JobState = "California",
                        SafetyCode = "ASME A17.1-2004 w/CA TITLE 8,GROUP IV ",
                        JobType = "M4000",
                        ShipDate = new DateTime(2017, 12, 12)
                    },
                    new Job
                    {
                        Name = "PACIFIC PALISADES LAUSD CHARTER HIGH SCHOOL",
                        JobNum = 2017088536,
                        PO = 3397819,
                        Cust = "CAEE2999",
                        JobState = "California",
                        SafetyCode = "ASME A17.1-2004 w/CA TITLE 8,GROUP IV ",
                        JobType = "ELEM",
                        ShipDate = new DateTime(2017, 11, 13)
                    },
                    new Job
                    {
                        Name = "SMC ADMIN",
                        JobNum = 2017088535,
                        PO = 3397817,
                        Cust = "CAEE3000",
                        JobState = "California",
                        SafetyCode = "ASME A17.1-2004 w/CA TITLE 8,GROUP IV ",
                        JobType = "M2000",
                        ShipDate = new DateTime(2018, 1, 26)
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
