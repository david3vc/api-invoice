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
    public class InvoiceIssuerMap : IEntityTypeConfiguration<InvoiceIssuer>
    {
        public void Configure(EntityTypeBuilder<InvoiceIssuer> builder)
        {
            builder.ToTable("invoice_issuer");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_invoice_issuer");
            builder.Property(e => e.StreetAddress).HasColumnName("street_address");
            builder.Property(e => e.City).HasColumnName("city");
            builder.Property(e => e.PostCode).HasColumnName("post_code");
            builder.Property(e => e.Country).HasColumnName("country");
        }
    }
}
