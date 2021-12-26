using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Livraria_Lunar_E_commerce.Models
{
    public class ItemCompra
    {
        [Key]
        public Guid cd_itemCompras { get; set; }

        public int cd_compra { get; set; }

        public int cd_produto { get; set; }

        public string nm_produto { get; set; }

        public double valorUnit { get; set; }

        public double valorParcial { get; set; }

        public int qtdeVendas { get; set; }

        public string img { get; set; }
    }
}