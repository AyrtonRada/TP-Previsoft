using Adrian.core.Config;
using Adrian.core.Models.CONF;
using Empujar.core.Models.CONF;
using Microsoft.EntityFrameworkCore;


namespace Adrian.core.DbContexts
{
    public class WebDBContext : DbContext
    {
        /*GRAL*/


        /*CONF*/
        public DbSet<TipoDeCentroDeCosto> TiposDeCentroDeCosto { get; set; }
        public DbSet<Material> Materiales { get; set; }

        /*OPER*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigDB.MainDBConnectionString);
        }

    }
}
