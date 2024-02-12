using EmpresasApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresasApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface para os métodos de serviço de domínio de empresa
    /// </summary>

    public interface IEmpresaDomainService 
    {
        void Cadastrar(Empresa empresa);
        void Atualizar(Empresa empresa);
        void Excluir(Guid id);

        List<Empresa> Consultar();
        Empresa ObterPorId(Guid id);
        Empresa ObterPorRazaoSocial(String razaosocial);
        Empresa ObterPorCnpj(String cnpj);

    }
}
