using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Livraria_Lunar_E_commerce.Models
{
    public class Livros
    {
        public int cd_produto { get; set; }

        [Display(Name = "Nome do produto")]
        [Required(ErrorMessage = "O campo Nome do produto é obrigatório")]
        [MaxLength(70, ErrorMessage = "O Nome do produto deve conter no máximo 70 caracteres")]
        public string nm_produto { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "O campo Quantidade no Estoque é obrigatório")]
        [Range(1, 1000, ErrorMessage = "A quantidade do produto deve estar entre 1 e 1000")]
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




        [Display(Name = "Número de Páginas")]
        [Required(ErrorMessage = "O campo Número de Páginas é obrigatório")]
        public int no_paginas { get; set; }

        [Display(Name = "ISBN")]
        [Required(ErrorMessage = "O campo ISBN é obrigatório")]
        [MinLength(13,ErrorMessage = "O ISBN deve conter 13 dígitos")]
        [MaxLength(13,ErrorMessage = "O ISBN deve conter 13 dígitos")]
        public string no_isbn { get; set; }


        [Display(Name = "Data de publicação")]
        [Required(ErrorMessage = "O Data de publicação do é obrigatório")]
        public DateTime dt_publicada { get; set; }

        [Display(Name = "Autor")]
        [Required(ErrorMessage = "O campo Autor é obrigatório")]
        public int cd_autor { get; set; }


        [Display(Name = "Autor")]
        public string nm_autor { get; set; }

        [Display(Name = "Editora")]
        [Required(ErrorMessage = "O campo Editora é obrigatório")]
        public int cd_editora { get; set; }

        [Display(Name = "Editora")]
        public string nm_editora { get; set; }
    }
}