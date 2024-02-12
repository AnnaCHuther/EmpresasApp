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
    /// Repositório de banco de dados para empresa
    /// </summary>

    public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
    {
        public Empresa GetByCnpj(string cnpj)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Empresa>()
                    .Where(u => u.Cnpj.Equals(cnpj))
                    .FirstOrDefault();

            }
        }

        public Empresa GetByRazaoSocial(string razaosocial)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Empresa>()
                    .Where(u => u.RazaoSocial.Equals(razaosocial))
                    .FirstOrDefault();

            }
        }
    }
}
