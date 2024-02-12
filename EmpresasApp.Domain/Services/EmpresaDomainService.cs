using EmpresasApp.Domain.Entities;
using EmpresasApp.Domain.Interfaces.Repositories;
using EmpresasApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresasApp.Domain.Services
{
    /// <summary>
    /// Classe de serviços de domínio para Empresa
    /// </summary>

    public class EmpresaDomainService : IEmpresaDomainService
    {
        private readonly IEmpresaRepository? _empresaRepository;

        public EmpresaDomainService(IEmpresaRepository? empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public void Cadastrar(Empresa empresa)
        {
            //buscar a empresa no banco de dados através da razao social
            var empresa1 = _empresaRepository?.GetByRazaoSocial(empresa.RazaoSocial);
            //verificar se a matricula do funcionario não existe no banco de dados
            if (empresa1 != null)
                throw new ApplicationException("A razao social informada já existe. Por favor, verifique.");

            //buscar a empresa no banco de dados através do cnpj
            var empresa2 = _empresaRepository?.GetByCnpj(empresa.Cnpj);
            //verificar se o Cpf do funcionario não existe no banco de dados
            if (empresa2 != null)
                throw new ApplicationException("O Cnpj informado já existe. Por favor, verifique.");

            //gerando um id para o empresa
            empresa.Id = Guid.NewGuid();

            //gerando a data e hora de criação
            empresa.DataHoraCadastro = DateTime.Now;

            //gravar a empresa no banco de dados
            _empresaRepository?.Add(empresa);

        }

        public void Atualizar(Empresa empresa)
        {
            //verificar se a empresa informada 
            //não existe no banco de dados
            if (_empresaRepository?.GetById(empresa.Id.Value) == null)
                throw new ApplicationException
                 ("A empresa informada não existe. Por favor, verifique.");

            //buscar a empresa no banco de dados através da razao social
            var empresa1 = _empresaRepository?.GetByRazaoSocial(empresa.RazaoSocial);
  
            //verificar se a matricula do funcionario não existe no banco de dados
            if (empresa1.RazaoSocial != empresa.RazaoSocial)
                if (empresa1 != null)
                throw new ApplicationException("A razao social informada já existe. Por favor, verifique.");
 
            //buscar a empresa no banco de dados através do cnpj
            var empresa2 = _empresaRepository?.GetByCnpj(empresa.Cnpj);
            //verificar se o Cpf do funcionario não existe no banco de dados
            if (empresa2.Cnpj != empresa.Cnpj)
                if (empresa2 != null)
                throw new ApplicationException("O Cnpj informado já existe. Por favor, verifique.");

            //gerando a data e hora de criação
            empresa.DataHoraCadastro = DateTime.Now;

            //atualizar a empresa
            _empresaRepository?.Update(empresa);
        }

        public void Excluir(Guid id)
        {
            //buscar a empresa no banco de dados através do Id
            var empresa = _empresaRepository?.GetById(id);

            //verificar se o Id do funcionario não existe no banco de dados
            if (empresa == null)
                throw new ApplicationException("O empresa informada não existe. Por favor, verifique.");

            //excluir a empresa
            _empresaRepository?.Delete(empresa);
        }

        public List<Empresa> Consultar()
        {
            return _empresaRepository?.GetAll();
        }



        public Empresa ObterPorId(Guid id)
        {
            return _empresaRepository?.GetById(id);
        }

        Empresa IEmpresaDomainService.ObterPorRazaoSocial(string razaosocial)
        {
            return _empresaRepository?.GetByRazaoSocial(razaosocial);
        }

        Empresa IEmpresaDomainService.ObterPorCnpj(string cnpj)
        {
            return _empresaRepository?.GetByCnpj(cnpj);
        }
    }
}
