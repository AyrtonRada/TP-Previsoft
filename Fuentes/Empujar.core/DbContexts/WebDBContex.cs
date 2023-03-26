using Empujar.core.Config;
using Empujar.core.Models.CONF;
using Microsoft.EntityFrameworkCore;


namespace Empujar.core.DbContexts
{
    public class WebDBContext : DbContext
    {
        /*GRAL*/


        /*CONF*/
        public DbSet<TipoDeCentroDeCosto> TiposDeCentroDeCosto { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<Galpon> Galpones { get; set; }
        public DbSet<TipoDeGasto> TiposDeGasto { get; set; }

        /*OPER*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigDB.MainDBConnectionString);
        }

    }
}
