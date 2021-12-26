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
        [MaxLength(70, ErrorMessage = "O Nome do produto deve conter no máximo 70 caracteres")]
        public string nm_produto { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "O campo Quantidade no Estoque é obrigatório")]
        [Range(1,1000,ErrorMessage = "A quantidade do produto deve estar entre 1 e 1000")]
        public int qt_estoque { get; set; }


        [Display(Name = "Valor unitário")]
   
        [Required(ErrorMessage = "O campo Valor unitário é obrigatório")]
        public Decimal vl_unitario { get; set; }


        [Display(Name = "Imagem do produto")]
        public string img_produto { get; set; }

        [Display(Name = "Descrição do produto")]
        [Required(ErrorMessage = "O campo Descrição do produto é obrigatório")]
        [MaxLength(1000, ErrorMessage = "A descrição deve conter no máximo 1000 caracteres")]
        public string desc_produto { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "O campo Categoria é obrigatório")]
        public int cd_categoria { get; set; }

        [Display(Name = "Categoria")]
        public string nm_categoria { get; set; }


        [Display(Name = "Número de Páginas")]
        public int no_paginas { get; set; }

        [Display(Name = "ISBN")]
        public string no_isbn { get; set; }


        [Display(Name = "Data de publicação")]
        public DateTime dt_publicada { get; set; }

        [Display(Name = "Autor")]
        public int cd_autor { get; set; }


        [Display(Name = "Autor")]
        public string nm_autor { get; set; }

        [Display(Name = "Editora")]
        public int cd_editora { get; set; }

        [Display(Name = "Editora")]
        public string nm_editora { get; set; }
    }
}