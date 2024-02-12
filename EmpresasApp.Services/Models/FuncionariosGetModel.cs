namespace EmpresasApp.Services.Models
{
    /// <summary>
    /// modelo de dados para resposta de consulta de empresas
    /// GET / api/funcionarios
    /// </summary>
    public class FuncionariosGetModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Matricula { get; set; }
        public string? Cpf { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
        public Guid? EmpresaId { get; set; }
    }
}
