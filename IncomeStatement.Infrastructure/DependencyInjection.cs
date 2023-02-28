using IncomeStatement.Domain.Common;
using IncomeStatement.Domain.Statement.Interfaces;
using IncomeStatement.Infrastructure.Persistance;
using IncomeStatement.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IncomeStatement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
