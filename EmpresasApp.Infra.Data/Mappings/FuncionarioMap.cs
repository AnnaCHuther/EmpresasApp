using EmpresasApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresasApp.Infra.Data.Mappings
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("FUNCIONARIO");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .HasColumnName("ID");

            builder.Property(f => f.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(f => f.Matricula)
               .HasColumnName("MATRICULA")
               .HasMaxLength(8)
               .IsRequired();

            builder.Property(f => f.Cpf)
               .HasColumnName("CPF")
               .HasMaxLength(11)
               .IsRequired();

            builder.Property(f => f.DataAdmissao)
               .HasColumnName("DATAADMISSAO")
               .IsRequired();

            builder.Property(f => f.DataHoraCadastro)
               .HasColumnName("DATAHORACADASTRO")
               .IsRequired();

            builder.Property(f => f.EmpresaId)
               .HasColumnName("EMPRESAID")
               .IsRequired();

            builder.HasIndex(f => f.Cpf)
                .IsUnique();
            builder.HasIndex(f => f.Matricula)
                .IsUnique();

            builder.HasOne(f => f.Empresa)         //Funcionário tem 1 empresa
                 .WithMany(e => e.Funcionarios)    //Empresa tem muitos funcionarios
                 .HasForeignKey(f => f.EmpresaId); //CHAVE ESTRANGEIRA

        }
    }
}
