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
    /// Classe para implementar o repositório genérico do sistema
    /// </summary>

    public class BaseRepository<T> : IBaseRespository<T>
        where T : class
    {
        public void Add(T entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(entity);
                dataContext.SaveChanges();
            }

        }

        public void Update(T entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(entity);
                dataContext.SaveChanges();
            }

        }

        public void Delete(T entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(entity);
                dataContext.SaveChanges();
            }

        }

        public List<T> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<T>().ToList();
            }

        }

        public T GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<T>().Find(id);
            }

        }

    }
}
