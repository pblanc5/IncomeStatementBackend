using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeStatement.Database
{
    internal class CommandLineOptions
    {
        [Option('u', "up", HelpText = "Applies database changes")]
        public bool Up { get; set; }
        [Option('d', "down", HelpText = "Removes database changes")]
        public bool Down { get; set; }
        [Option('c', "connection", HelpText = "Database connection string")]
        public string? ConnectionString { get; set; }
        [Option('v', "version", HelpText = "Database migration version")]
        public long Version { get; set; }
    }
}
