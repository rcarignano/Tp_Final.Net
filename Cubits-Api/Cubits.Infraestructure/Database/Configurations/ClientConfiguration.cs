using Cubits.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubits.Infraestructure.Database.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("clientes");

            builder.HasKey(r => r.ClientId);

            builder.Property(r => r.ClientId)
                .HasColumnName("id_cliente");

            builder.Property(r => r.Name)
                .HasColumnName("nombre");

            builder.Property(r => r.StreetName)
                .HasColumnName("direccion");

            builder.Property(r => r.City)
                .HasColumnName("ciudad");

            builder.Property(r => r.Province)
                .HasColumnName("provincia");

            builder.Property(r => r.Region)
                .HasColumnName("zona");
        }
    }
}
