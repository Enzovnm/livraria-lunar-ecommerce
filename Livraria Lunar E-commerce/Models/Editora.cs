using System.ComponentModel.DataAnnotations;

namespace Livraria_Lunar_E_commerce.Models
{
    public class Editora
    {

        [Display(Name = "Código")]
        public int cd_editora { get; set; }

        [Required(ErrorMessage = "O Campo Nome da Editora é obrigatório")]
        [Display(Name= "Nome da Editora")]
        [MaxLength(70,ErrorMessage = "O Nome da Editora deve conter no máximo 70 caracteres")]
        public string nm_editora { get; set; }
    }
}