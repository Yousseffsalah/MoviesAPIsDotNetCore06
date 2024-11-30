using Microsoft.Extensions.Logging;
using Movies.DAL.Data;
using Movies.DAL.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Movies.Repositry.Data_Seed
{
    public class DataSeeding
    {
        public async static Task DataSeedAsync(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {

           

          
                // for: Genres
                await AddDateSeedToContext<Genre>(context, "Genres", loggerFactory);

                // for: Movies
                await AddDateSeedToContext<Movie>(context, "Movies", loggerFactory);

              

            

        }

        private async  static Task AddDateSeedToContext<T>(ApplicationDbContext context, string fileName,  ILoggerFactory loggerFactory) where T : BaseEntity
        {
            if (context.Set<T>().Count() <= 0)
            {
                
                var Items = File.ReadAllText($"../Movies.BAL/DataSeed/{fileName}.json");

                var ItemsList = JsonSerializer.Deserialize<List<T>>(Items);

                try
                {
                    if (ItemsList is not null)
                        foreach (var item in ItemsList)
                            context.Set<T>().Add(item);

                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<DataSeeding>();

                    logger.LogError(ex.ToString());

                }

            }

        }


    }
}
