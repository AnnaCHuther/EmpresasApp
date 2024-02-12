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
    public class FuncionarioDomainService : IFuncionarioDomainService
    {
        private readonly IFuncionarioRepository? _funcionarioRepository;    
        private readonly IEmpresaRepository? _empresaRepository;


        public FuncionarioDomainService(IFuncionarioRepository? funcionarioRepository, IEmpresaRepository? empresaRepository)
        {
            _funcionarioRepository = funcionarioRepository;
            _empresaRepository = empresaRepository;
        }

        public void Atualizar(Funcionario funcionario)
        {
            //verificar se o Id do funcionario não existe no banco de dados
            if (_funcionarioRepository?.GetById(funcionario.Id.Value) == null)
            throw new ApplicationException
             ("O funcionario informado não existe. Por favor, verifique.");

            //buscar o funcionario no banco de dados através da matricula
            var funcionario1 = _funcionarioRepository?.GetByMatricula(funcionario.Matricula);
            //verificar se a matricula do funcionario não existe no banco de dados
            if (funcionario1 != null)
                throw new ApplicationException("A matricula informada já existe. Por favor, verifique.");

            //buscar o funcionario no banco de dados através do cpf
            var funcionario2 = _funcionarioRepository?.GetByCpf(funcionario.Cpf);
            //verificar se o Cpf do funcionario não existe no banco de dados
            if (funcionario2 != null)
                throw new ApplicationException("O Cpf informado já existe. Por favor, verifique.");

            //verificar se a empresa informada 
            //não existe no banco de dados
            if (_empresaRepository?.GetById
               (funcionario.EmpresaId.Value) == null)
            throw new ApplicationException("A empresa informada não existe.Por favor, verifique.");

            //gerando a data e hora de criação
            funcionario.DataHoraCadastro = DateTime.Now;

            //atualizar a funcionario
            _funcionarioRepository?.Update(funcionario);

        }

        public void Cadastrar(Funcionario funcionario)
        {
            //buscar o funcionario no banco de dados através da matricula
            var funcionario1 = _funcionarioRepository?.GetByMatricula(funcionario.Matricula);
            //verificar se a matricula do funcionario não existe no banco de dados
            if (funcionario1 != null)
                throw new ApplicationException("A matricula informada já existe. Por favor, verifique.");

            //buscar o funcionario no banco de dados através do cpf
            var funcionario2 = _funcionarioRepository?.GetByCpf(funcionario.Cpf);
            //verificar se o Cpf do funcionario não existe no banco de dados
            if (funcionario2 != null)
                throw new ApplicationException("O Cpf informado já existe. Por favor, verifique.");

            //verificar se a empresa informada 
            //não existe no banco de dados
            if (_empresaRepository?.GetById
               (funcionario.EmpresaId.Value) == null)
            throw new ApplicationException("A Empresa informada não existe.Por favor, verifique.");

            //gerando um id para o funcionario
            funcionario.Id = Guid.NewGuid();

            //gerando a data e hora de criação
            funcionario.DataHoraCadastro = DateTime.Now;

            //gravar o funcionario no banco de dados
            _funcionarioRepository?.Add(funcionario);
        }

        public void Excluir(Guid id)
        {
            //buscar a funcionario no banco de dados através do Id
            var funcionario = _funcionarioRepository?.GetById(id);

            //verificar se o Id do funcionario não existe no banco de dados
            if (funcionario == null)
                throw new ApplicationException("O funcinario informado não existe. Por favor, verifique.");

            //excluir a funcionario
            _funcionarioRepository?.Delete(funcionario);

        }

        public List<Funcionario> Consultar()
        {
            return _funcionarioRepository?.GetAll();
        }


        public Funcionario ObterPorId(Guid id)
        {
            return _funcionarioRepository?.GetById(id);
        }

        Funcionario IFuncionarioDomainService.ObterPorMatricula(string matricula)
        {
            return _funcionarioRepository?.GetByMatricula(matricula);
        }

        Funcionario IFuncionarioDomainService.ObterPorCpf(string cpf)
        {
            return _funcionarioRepository?.GetByCpf(cpf);
        }
    }
}
