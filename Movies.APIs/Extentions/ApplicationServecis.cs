using Microsoft.AspNetCore.Mvc;
using Movies.BAL.Interfaces.UnitOfWork;
using Movies.BAL.Repository;
using Movies.DAL.Data.Entites;
using Movies.PL.APIs.Errors;
using Movies.PL.APIs.Helpers;

namespace Movies.PL.APIs.Extentions
{
    public static class ApplicationServecis
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddAutoMapper(typeof(Mappingprofiles));

            //handel Validation Errors
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context =>
                {
                    var errors = context.ModelState
                                               .Where(M => M.Value.Errors.Count() > 0)
                                               .SelectMany(E => E.Value.Errors)
                                               .Select(E => E.ErrorMessage)
                                               .ToList();

                    var apiValidationResponse = new ApiValidationsErrorResponse()
                    {
                        Errors= errors
                    };

                    return new BadRequestObjectResult(apiValidationResponse);
                }
                );

            }
                );


            return services;
        }

    }
}
