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
    public class InvoiceStatusMap : IEntityTypeConfiguration<InvoiceStatus>
    {
        public void Configure(EntityTypeBuilder<InvoiceStatus> builder)
        {
            builder.ToTable("invoice_status");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_invoice_status");
            builder.Property(e => e.Name).HasColumnName("name");
        }
    }
}
