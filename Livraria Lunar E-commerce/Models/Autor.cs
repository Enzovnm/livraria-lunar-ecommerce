using System.ComponentModel.DataAnnotations;

namespace Livraria_Lunar_E_commerce.Models
{
    public class Autor
    {

        [Display(Name = "Código")]
        public int cd_autor { get; set; }

        [Required(ErrorMessage = "O Campo Nome do Autor é obrigatório")]
        [Display(Name= "Nome do Autor")]
        [MaxLength(70,ErrorMessage = "O Nome do Autor deve conter no máximo 70 caracteres")]
        public string nm_autor { get; set; }

        [Required]
        [Display(Name = "Status")]
        [Range(0,1)]
        public int ds_status { get; set; }
    }

}