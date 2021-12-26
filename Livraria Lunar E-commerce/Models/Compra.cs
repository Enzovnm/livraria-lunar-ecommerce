using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria_Lunar_E_commerce.Models
{
    public class Compra
    {
        public int cd_compra { get; set; }

        public double vl_total { get; set; }

        public int cd_cliente { get; set; }

        public int cd_pagamento { get; set; }

        public List<ItemCompra> ItensDaCompra = new List<ItemCompra>();
    }
}