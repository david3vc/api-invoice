using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.ModelMaps
{
    internal class InvoiceItemMap : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.ToTable("invoice_item");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_invoice_item");
            builder.Property(e => e.Name).HasColumnName("name");
            builder.Property(e => e.Quantity).HasColumnName("quantity");
            builder.Property(e => e.Price).HasColumnName("price");
            builder.Property(e => e.Total).HasColumnName("total");
            builder.Property(e => e.Status).HasColumnName("status");
            builder.Property(e => e.IdInvoice).HasColumnName("id_invoice");

            builder.HasOne(f => f.Invoice).WithMany(g => g.InvoiceItems).HasForeignKey(f => f.IdInvoice);
        }
    }
}
