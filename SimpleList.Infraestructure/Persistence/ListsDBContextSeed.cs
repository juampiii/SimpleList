using Microsoft.Extensions.Logging;
using SimpleList.Domain;

namespace SimpleList.Infraestructure.Persistence
{
    public class ListsDBContextSeed
    {
        public static async Task SeedDBAsync(ListsDBContext dBContext, ILogger<ListsDBContextSeed> logger)
        {
            if (!dBContext.Lists!.Any())
            {
                dBContext.Lists!.AddRange(GetPreconfiguredLists());
            }

            await dBContext.SaveChangesAsync();
            logger.LogInformation("Base records insertions");
        }

        private static IEnumerable<List> GetPreconfiguredLists()
        {
            return new List<List>() 
                {
                    new List()
                    {
                        Name = "ShopList",
                        CreationUserId = 1,
                        CreationDate = new DateTime(2022,12,10, 12, 12, 12)
                    },
                    new List()
                    {
                        Name = "Grocery Stuffs",
                        CreationUserId = 2,
                        CreationDate = new DateTime(2022,12,10, 13, 12, 12)
                    }
                };
        }
    }
}
