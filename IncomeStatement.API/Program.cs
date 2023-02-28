
using IncomeStatement.Application;
using IncomeStatement.Infrastructure;
using IncomeStatement.Infrastructure.Persistance;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using IncomeStatement.API.Middleware;

namespace IncomeStatement.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console());

            // Add services to the container.
            builder.Services.AddSingleton<DapperContext>();
            builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        var factory = context.HttpContext.RequestServices
                            .GetRequiredService<ProblemDetailsFactory>();
                        var problemDetails = factory.CreateValidationProblemDetails(context.HttpContext, context.ModelState);

                        problemDetails.Detail = "See the errors field for details";
                        problemDetails.Instance = context.HttpContext.Request.Path;

                        problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
                        problemDetails.Title = "One or more validation errors occured";

                        return new UnprocessableEntityObjectResult(problemDetails)
                        {
                            ContentTypes = { "application/problem+json" }
                        };
                    };
                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.UseSerilogRequestLogging();
            app.UseMiddleware<ExceptionMiddleware>();
            app.Run();
        }
    }
}