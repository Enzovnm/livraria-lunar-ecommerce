using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Livraria_Lunar_E_commerce.Models
{
    public class Cliente
    {
        [Display(Name = "Código")]
        public int cd_cliente { get; set; }

        [Required(ErrorMessage = "O Campo Nome do Cliente é obrigatório")]
        [Display(Name = "Nome do Cliente")]
        [MaxLength(70, ErrorMessage = "O nome do Cliente deve conter no máximo 70 caracteres")]
        public string nm_cliente { get; set; }

        [Required]
        [Display(Name = "Email")]
        [MaxLength(70, ErrorMessage = "O Email do Cliente deve conter no máximo 70 caracteres")]
        public string ds_email { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [MaxLength(20, ErrorMessage = "A senha do Cliente deve conter no máximo 20 caracteres")]
        [MinLength(8, ErrorMessage = "A senha deve conter no mínimo 8 caracteres")]
        public string ds_senha { get; set; }

        [Required]
        [Display(Name = "CPF")]
        public string cpf { get; set; }

        [Required]
        [Display(Name = "Telefone")]
        public string telefone { get; set; }

        [Required]
        [Display(Name = "Celular")]
        public string celular { get; set; }

        [Required]
        [Display(Name = "Endereço")]
        [MaxLength(70, ErrorMessage = "O Endereço deve conter no máximo 160 caracteres")]
        public string rua { get; set; }

        [Required]
        [Display(Name = "Número")]
        [MaxLength(5, ErrorMessage = "O Número deve conter no máximo 5 dígitos")]
        [RegularExpression("([1-9][0-9]*)")]
        public string no_logradouro { get; set; }

        [Required]
        [Display(Name = "Bairro")]
        [MaxLength(120, ErrorMessage = "O Bairro deve conter no máximo 120 caracteres")]
        public string bairro { get; set; }


        [Required]
        [Display(Name = "Cidade")]
        [MaxLength(120, ErrorMessage = "A Cidade deve conter no máximo 120 caracteres")]
        public string cidade { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [MinLength(2, ErrorMessage = "A UF deve conter no mínimo 2 caracteres")]
        [MaxLength(2, ErrorMessage = "A UF deve conter no máximo 2 caracteres")]
        public string uf { get; set; }


        [Required]
        [Display(Name = "CEP")]
        [MinLength(8, ErrorMessage = "O CEP deve conter no mínimo 9 caracteres")]
        [MaxLength(8, ErrorMessage = "O CEP deve conter no máximo 9 caracteres")]
        public string cep { get; set; }

        [Required]
        [Display(Name = "Sexo")]
        public string sg_sexo { get; set; }


        

    }
}