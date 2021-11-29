using System;
using System.ComponentModel.DataAnnotations;

namespace Livraria_Lunar_E_commerce.Models
{
    public class Comentarios
    {
        [Display(Name = "Código")]
        public int cd_comentario { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "O Comentário deve conter no máximo 1000 caracteres")]
        [Display(Name = "Comentário")]
        public string ds_comentario { get; set; }

        [Display(Name = "Código do Usuário")]
        public int cd_usuario { get; set; }

        [Display(Name = "Nome do Usuário")]
        public string nm_usuario { get; set; }

        [Display(Name = "Data do Comentário")]
        public DateTime dt_comentario { get; set; }
    }
}