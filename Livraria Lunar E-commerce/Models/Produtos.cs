using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Livraria_Lunar_E_commerce.Models
{
    public class Produtos
    {
        public int cd_produto { get; set; }

        [Display(Name = "Nome do produto")]
        [Required(ErrorMessage = "O campo Nome do produto é obrigatório")]
        public string nm_produto { get; set; }

        [Display(Name = "Quantidade no Estoque")]
        [Required(ErrorMessage = "O campo Quantidade no Estoque é obrigatório")]
        public int qt_estoque { get; set; }


        [Display(Name = "Valor unitário")]
        [Required(ErrorMessage = "O campo Valor unitário é obrigatório")]
        public decimal vl_unitario { get; set; }


        [Display(Name = "Imagem do produto")]
        public string img_produto { get; set; }

        [Display(Name = "Descrição do produto")]
        [Required(ErrorMessage = "O campo Descrição do produto é obrigatório")]
        public string desc_produto { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "O campo Categoria é obrigatório")]
        public int cd_categoria { get; set; }


    }
}