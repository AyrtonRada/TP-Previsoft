﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Adrian.core.Models.CONF
{
    [Table("CONF_TiposDeCentroDeCosto")]
    public class TipoDeCentroDeCosto
    {

        [Key]
        public int ID { get; set; }

        public string Nombre { get; set; }

        //PADRES

        //HIJOS
    }
}