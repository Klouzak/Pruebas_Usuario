using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Infraestructura.Persistencia
{
    public class Db_Context_Factory : IDesignTimeDbContextFactory<Db_Context>
    {
        public Db_Context CreateDbContext(string[] args)
        {
            var configuracion = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

            var Conexion_Postgres = configuracion.GetConnectionString("Conexion_Postgres");

            var options_Builder = new DbContextOptionsBuilder<Db_Context>();
            options_Builder.UseNpgsql(Conexion_Postgres);
            return new Db_Context(options_Builder.Options);

        }


    }

}


