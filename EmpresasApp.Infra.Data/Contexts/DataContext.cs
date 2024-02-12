using EmpresasApp.Domain.Entities;
using EmpresasApp.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresasApp.Infra.Data.Contexts
{
    /// <summary>
    /// Classe para mapeamento da conexão do banco de dados
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Método para configurar o banco de dados do projeto
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBEmpresasApp;Integrated Security=True;");
        }

        /// <summary>
        /// Método para adicionarmos cada classe de mapeamento do projeto
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
        }

        //DbSet -> fornecer os métodos de CRUD para cada entidade
        public DbSet<Empresa>? empresa { get; set; }
        public DbSet<Funcionario>? funcionario { get; set; }
    }
}
