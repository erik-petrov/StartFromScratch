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
            new RealEstate{Address="House 1", Area=60f, Cost=600, ImageLink = "https://i.pinimg.com/originals/a1/c7/10/a1c710b599e8b83e74fef1371653987b.png"},
            new RealEstate{Address="House 2", Area=120f, Cost=1200, ImageLink = "https://images.pexels.com/photos/186077/pexels-photo-186077.jpeg?cs=srgb&dl=pexels-binyamin-mellish-186077.jpg&fm=jpg"},
            new RealEstate{Address="House 3", Area=120f, Cost=1200, ImageLink = "https://images.unsplash.com/photo-1570129477492-45c003edd2be?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxleHBsb3JlLWZlZWR8Mnx8fGVufDB8fHx8&w=1000&q=80"},
            new RealEstate{Address="House 4", Area=120f, Cost=1200, ImageLink = "https://images.adsttc.com/media/images/5ecd/d4ac/b357/65c6/7300/009d/newsletter/02C.jpg?1590547607"},
            };
            foreach (RealEstate c in estates)
            {
                context.RealEstates.Add(c);
            }
            context.SaveChanges();

            context.Agents.Add(new Agent { Email = "Email@email.com",
                FullName = "AMogus AMogusovich",
                Password = "123132",
                Phone = "+372561231231",
                YearsInField = 7});

            context.SaveChanges();
        }
    }
}
