﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Suma1925597
{
    [Table("resultado")]
    public class Resultado
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("numero1")]
        public string? Numero1 { get; set; }
        [Column("numero2")]
        public string? Numero2 { get; set; }
        [Column("suma")]
        public string? Suma { get; set; }
    }
}
