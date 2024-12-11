using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementDAL.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StudentDBContext>
    {
        public StudentDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentDBContext>();

            // Optionally, you can load the connection string from a configuration file
            var connectionString = "Server=hipposcriptsinterview.database.windows.net;Database=hipposcriptsinterview;User Id=hs_interview;Password=HippoScripts1334!;";

            optionsBuilder.UseSqlServer(connectionString);

            return new StudentDBContext(optionsBuilder.Options);
        }
    }
}
