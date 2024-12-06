using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AyberkInterview.DataAccessLayers
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StudentDbContext>
    {
        public StudentDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentDbContext>();

            // Optionally, you can load the connection string from a configuration file
            var connectionString = "Server=hipposcriptsinterview.database.windows.net;Database=hipposcriptsinterview;User Id=hs_interview;Password=HippoScripts1334!;";

            optionsBuilder.UseSqlServer(connectionString);

            return new StudentDbContext(optionsBuilder.Options);
        }
    }
}
