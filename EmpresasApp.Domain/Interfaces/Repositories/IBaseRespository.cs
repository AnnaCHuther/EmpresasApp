using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresasApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface genérica para construção dos métodos do repositório
    /// </summary>

    public interface IBaseRespository<T> 
        where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        List<T> GetAll();
        T GetById(Guid id);

    }
}
