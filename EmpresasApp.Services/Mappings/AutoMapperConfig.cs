using AutoMapper;
using EmpresasApp.Domain.Entities;
using EmpresasApp.Services.Models;

namespace EmpresasApp.Services.Mappings
{
    /// <summary>
    /// Classe para mapeamento das cópias de dados feitas pelo AutoMapper
    /// </summary>

    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<EmpresasPostModel, Empresa>()
            .AfterMap((model, entity) =>
            {
              entity.Id = Guid.NewGuid();
            });

            CreateMap<FuncionariosPostModel, Funcionario>()
            .AfterMap((model, entity) =>
            {
              entity.Id = Guid.NewGuid();
            });

            //Copiar os dados de Empresa para > EmpresaGetModel
            CreateMap<Empresa, EmpresasGetModel>();

            //Copiar os dados de EmpresasPutModel para > Empresas
            CreateMap<EmpresasPutModel, Empresa>();

            //Copiar os dados de Funcionario para > FuncionarioGetModel
            CreateMap<Funcionario, FuncionariosGetModel>();

            //Copiar os dados de FuncionariosPutModel para > Funcionarios
            CreateMap<FuncionariosPutModel, Funcionario>();

        }
    }
}
