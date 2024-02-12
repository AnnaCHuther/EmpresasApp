using EmpresasApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresasApp.Domain.Interfaces.Repositories
{
    public interface IFuncionarioRepository : IBaseRespository<Funcionario>
    {
        Funcionario GetByMatricula(String matricula);
        Funcionario GetByCpf(String cpf);
    }
}
