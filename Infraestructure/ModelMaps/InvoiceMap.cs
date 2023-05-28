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
    public class InvoiceMap : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("invoice");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_invoice");
            builder.Property(e => e.ProjectDescription).HasColumnName("project_description");
            builder.Property(e => e.InvoiceDate).HasColumnName("invoice_date");
            builder.Property(e => e.IdPaymentTerm).HasColumnName("id_payment_term");
            builder.Property(e => e.IdInvoiceStatus).HasColumnName("id_invoice_status");
            builder.Property(e => e.IdSubject).HasColumnName("id_subject");
            builder.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            builder.Property(e => e.IdInvoiceIssuer).HasColumnName("id_invoice_issuer");
            builder.Property(e => e.Status).HasColumnName("status");

            builder.HasOne(f => f.InvoiceStatus).WithMany(g => g.Invoices).HasForeignKey(f => f.IdInvoiceStatus);
            builder.HasOne(f => f.PaymentTerm).WithMany(g => g.Invoices).HasForeignKey(f => f.IdPaymentTerm);
            builder.HasOne(f => f.Subject).WithMany(g => g.Invoices).HasForeignKey(f => f.IdSubject);
            builder.HasOne(f => f.Usuario).WithMany(g => g.Invoices).HasForeignKey(f => f.IdUsuario);
            builder.HasOne(f => f.InvoiceIssuer).WithMany(g => g.Invoices).HasForeignKey(f => f.IdInvoiceIssuer);
        }
    }
}
