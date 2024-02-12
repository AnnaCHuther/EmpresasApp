using EmpresasApp.Domain.Interfaces.Repositories;
using EmpresasApp.Domain.Interfaces.Services;
using EmpresasApp.Domain.Services;
using EmpresasApp.Infra.Data.Repositories;

namespace EmpresasApp.Services
{
    /// <summary>
    /// Classe para configurar as injeções de dependência do projeto
    /// </summary>

    public class DependencyInjection
    {
        /// <summary>
        /// Método para configurar as injeções de dependência do sistema
        /// </summary>
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IEmpresaDomainService, EmpresaDomainService>();
            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<IFuncionarioDomainService, FuncionarioDomainService>();
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();

        }

    }
}
