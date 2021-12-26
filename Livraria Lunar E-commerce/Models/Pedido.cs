using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Livraria_Lunar_E_commerce.Models
{
    public class Pedido
    {

        [Display(Name="Código da Compra")]
        public int cd_compra { get; set; }

        [Display(Name="Produto")]
        public string nm_produto { get; set; }

        [Display(Name="Total")]
        public decimal vl_total { get; set; }

        [Display(Name="Previsão de Entrega")]
        public DateTime dt_entrega { get; set; }

    }
}