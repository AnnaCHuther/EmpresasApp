using System.ComponentModel.DataAnnotations;

namespace EmpresasApp.Services.Models
{
    public class EmpresasPutModel
    {
        [Required(ErrorMessage = "Por favor, informe o Id da empresa desejada.")]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe a Razão Social.")]
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        public string? RazaoSocial { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome fantasia.")]
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(25, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        public string? NomeFantasia { get; set; }

        [Required(ErrorMessage = "Por favor, informe o CNPJ.")]
        [MinLength(14, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(14, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        public string? Cnpj { get; set; }
    }
}
