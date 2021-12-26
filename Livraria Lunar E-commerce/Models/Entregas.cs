using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Livraria_Lunar_E_commerce.Models
{
    public class Entregas
    {
        [Display(Name="Código da Entrega")]
        public int cd_entrega { get; set; }

        [Display(Name="Código da Compra")]
        public string cd_compra { get; set; }

        [Display(Name="Produto")]
        public string nm_produto { get; set; }

        [Display(Name="Total")]
        public decimal vl_total { get; set; }

        [Display(Name="Cliente")]
        public string nm_usuario { get; set; }

        [Display(Name="Previsão de Entrega")]
        public DateTime dt_entrega { get; set; }

        [Display(Name="CPF")]
        public string no_cpf { get; set; }

        [Display(Name="Celular")]
        public string no_celular { get; set; }

        [Display(Name="CEP")]
        public string no_cep { get; set; }

        [Display(Name="Endereço")]
        public string nm_logradouro { get; set; }

        [Display(Name="Número")]
        public string no_logradouro { get; set; }

        [Display(Name="Complemento")]
        public string ds_complemento { get; set; }
    }
}