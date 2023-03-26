using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Empujar.mvc.Models
{
    public class MaterialViewModel
    {
        [Required(ErrorMessage = "Requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Requerido.")]
        public double PrecioCompra{ get; set; }

        [Required(ErrorMessage = "Requerido.")]
        public double PrecioVenta { get; set; }
    }
}
