using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.ModelMaps
{
    public class PaymentTermMap : IEntityTypeConfiguration<PaymentTerm>
    {
        public void Configure(EntityTypeBuilder<PaymentTerm> builder)
        {
            builder.ToTable("payment_term");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_payment_term");
            builder.Property(e => e.Name).HasColumnName("name");
        }
    }
}
