namespace EmpresasApp.Services.Models
{
    /// <summary>
    /// modelo de dados para resposta de consulta de empresas
    /// GET / api/empresas
    /// </summary>
    public class EmpresasGetModel
    {
        public Guid? Id { get; set; }
        public string? RazaoSocial { get; set; }
        public string? NomeFantasia { get; set; }
        public string? Cnpj { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
    }
}
