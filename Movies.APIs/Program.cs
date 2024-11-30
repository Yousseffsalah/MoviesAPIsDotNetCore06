using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Movies.DAL.Data;
using Movies.PL.APIs.Extentions;
using Movies.PL.APIs.Helpers;
using Movies.PL.APIs.MiddleWares;
using Movies.Repositry.Data_Seed;
using System.ComponentModel.DataAnnotations;

namespace Movies.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //Configure Services
            #region Configure Services

            builder.Services.AddControllers();
            builder.Services.AddCors();

            //add applcation services
            builder.Services.AddApplicationServices();
            
            
            //Databases

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"));
            });

           


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSwaggerServices();

            #endregion
            

            var app = builder.Build();

            //Data Seeding 
            #region Data Seeding 
            var scope =  app.Services.CreateAsyncScope();

            var serviceProvider = scope.ServiceProvider;

          using  var _context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var _looger = serviceProvider.GetRequiredService<ILoggerFactory>();

            try
            {
                //migrate database
              await  _context.Database.MigrateAsync();
                //data seed
                await DataSeeding.DataSeedAsync(_context, _looger);
            }
            catch (Exception ex)
            {
                var logger = _looger.CreateLogger<Program>();
                logger.LogError(ex, ex.Message);

                throw;
            }


            #endregion


            // Configure the HTTP request pipeline.
            #region Configure Kestral MiddleWares
            app.UseMiddleware<ExptionMiddleWare>();
            if (app.Environment.IsDevelopment())
            {
                app.AddSwaggerMiddlewares();
            }

            // to catch internal errors and handle it and return spcifec Response for error
            // based on the enviroment 
            app.UseHttpsRedirection();

            app.UseStatusCodePagesWithReExecute("/error/{0}");
            app.UseStaticFiles();
            app.UseCors(c =>
            c.AllowAnyHeader()
             .AllowAnyMethod()
             .AllowAnyOrigin()
            );

            app.UseAuthorization();


            app.MapControllers();
            #endregion

            
            app.Run();
        }
    }
}