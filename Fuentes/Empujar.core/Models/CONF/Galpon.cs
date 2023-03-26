using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empujar.core.Models.CONF
{
    [Table("CONF_Galpones")]
    public class Galpon
    {

        [Key]
        public int ID { get; set; }

        public string Nombre { get; set; }

        //PADRES

        //HIJOS
    }
}
