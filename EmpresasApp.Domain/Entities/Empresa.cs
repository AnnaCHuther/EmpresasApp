using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresasApp.Domain.Entities
{
    /// <summary>
    /// Modelo de entidade para o banco de dados
    /// </summary>

    public class Empresa
    {
        public Guid? Id { get; set; }
        public string? RazaoSocial { get; set; }
        public string? NomeFantasia { get; set; }
        public string? Cnpj { get; set; }
        public DateTime? DataHoraCadastro { get; set; }

        #region Relacionamentos

        public List<Funcionario>? Funcionarios { get; set; }
        
        #endregion


    }
}
