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
    /// 
    public class Funcionario
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Matricula { get; set; }
        public string? Cpf { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
        public Guid? EmpresaId { get; set; }

        #region Relacionamentos

        public Empresa? Empresa { get; set; }

        #endregion


    }
}
