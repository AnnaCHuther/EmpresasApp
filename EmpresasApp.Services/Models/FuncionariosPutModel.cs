using System.ComponentModel.DataAnnotations;

namespace EmpresasApp.Services.Models
{
    public class FuncionariosPutModel
    {

        [Required(ErrorMessage = "Por favor, informe o Id do funcionario desejado.")]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do funcinário.")]
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a matricula do funcionário.")]
        [MinLength(1, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(8, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        public string? Matricula { get; set; }

        [Required(ErrorMessage = "Por favor, informe o cpf do funcionário.")]
        [MinLength(11, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(11, ErrorMessage = "Por favor, informe no máximo {1}caracteres.")]
        public string? Cpf { get; set; }

        [Required(ErrorMessage = "Por favor, informe data de admissão do funcionário.")]
        public DateTime? DataAdmissao { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id da empresa.")]
        public Guid? EmpresaId { get; set; }
    }
}
