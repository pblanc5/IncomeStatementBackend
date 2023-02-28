using IncomeStatement.Application.Category;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IncomeStatement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient<ICategoryService, CategoryService>();
        return services;
    }
}
