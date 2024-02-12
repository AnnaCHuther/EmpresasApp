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
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("EMPRESA");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("ID");

            builder.Property(e => e.NomeFantasia)
                .HasColumnName("NOMEFANTASIA")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(e => e.RazaoSocial)
               .HasColumnName("RAZAOSOCIAL")
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(e => e.Cnpj)
               .HasColumnName("CNPJ")
               .HasMaxLength(14)
               .IsRequired();

            builder.Property(e => e.DataHoraCadastro)
               .HasColumnName("DATAHORACADASTRO")
               .IsRequired();

            builder.HasIndex(e => e.Cnpj)
                .IsUnique();
            builder.HasIndex(e => e.RazaoSocial)
                .IsUnique();

        }
    }
}
