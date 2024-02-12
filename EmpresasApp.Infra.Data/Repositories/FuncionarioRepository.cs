using EmpresasApp.Domain.Entities;
using EmpresasApp.Domain.Interfaces.Repositories;
using EmpresasApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresasApp.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório de banco de dados para funcionario
    /// </summary>

    public class FuncionarioRepository : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        public Funcionario? GetByMatricula(String matricula)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Funcionario>()
                    .Where(u => u.Matricula.Equals(matricula))
                    .FirstOrDefault();

            }
        }

        public Funcionario? GetByCpf(String cpf)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Funcionario>()
                    .Where(u => u.Cpf.Equals(cpf))
                    .FirstOrDefault();

            }
        }

    }
}
