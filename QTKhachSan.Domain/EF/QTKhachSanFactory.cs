using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using QTKhachSan.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QTKhachSan.Domain.EF
{
    internal class QTKhachSanFactory : IDesignTimeDbContextFactory<QTKhachSanDb>
    {
        QTKhachSanDb IDesignTimeDbContextFactory<QTKhachSanDb>.CreateDbContext(string[] args)
        {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("ContextDB.json")
                    .Build();
                var connectionstring = configuration.GetConnectionString("db");
                var optionBuider = new DbContextOptionsBuilder<QTKhachSanDb>();
                optionBuider.UseSqlServer(connectionstring);
                return new QTKhachSanDb(optionBuider.Options);
            
        }
    }
}
