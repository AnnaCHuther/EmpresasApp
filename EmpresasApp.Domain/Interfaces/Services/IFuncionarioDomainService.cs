using EmpresasApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresasApp.Domain.Interfaces.Services
{
    public interface IFuncionarioDomainService
    {
        void Cadastrar(Funcionario funcionario);
        void Atualizar(Funcionario funcionario);
        void Excluir(Guid id);

        List<Funcionario> Consultar();
        Funcionario ObterPorId(Guid id);
        Funcionario ObterPorMatricula(String matricula);
        Funcionario ObterPorCpf(String cpf);
 
        
    }
}
