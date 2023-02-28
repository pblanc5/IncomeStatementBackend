using CommandLine;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Conventions;
using IncomeStatement.Database.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Database
{
    class Program
    {
        protected static void Main(string[] args)
        {
            InitCommandLine(args);
        }

        private static void InitCommandLine(string[] args)
        {
            Parser.Default
                .ParseArguments<CommandLineOptions>(args)
                .WithParsed(HandleCommanndLineOptions);
        }

        private static void HandleCommanndLineOptions(CommandLineOptions options)
        {
            using var serviceProvider = CreateServices(options.ConnectionString);
            using var scope = serviceProvider.CreateScope();
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

            if (options.Up)
                runner.MigrateUp();

            if (options.Down)
                runner.MigrateDown(options.Version);
        }

        private static ServiceProvider CreateServices(string connectionString)
        {
            return new ServiceCollection()
                .AddSingleton<IConventionSet>(new DefaultConventionSet("income", null))
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddPostgres()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(InitialSchema).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }
    }
}
