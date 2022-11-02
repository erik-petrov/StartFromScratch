using StartFromScratch.Models;
using System.Diagnostics;

namespace bruh.Database
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            if (context.RealEstates.Any())
            {
                return;
            }

            var estates = new RealEstate[]
            {
            new RealEstate{Address="House 1", Area=60f, Cost=600},
            new RealEstate{Address="House 2", Area=120f, Cost=1200},
            new RealEstate{Address="House 3", Area=120f, Cost=1200},
            new RealEstate{Address="House 4", Area=120f, Cost=1200},
            };
            foreach (RealEstate c in estates)
            {
                context.RealEstates.Add(c);
            }
            context.SaveChanges();

            context.Agents.Add(new Agent { Email = "Email@email.com", FullName = "AMogus AMogusovich", Password = "123132", Phone = "+372561231231", YearsInField = 7 });

            context.SaveChanges();
        }
    }
}
