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
    public class SubjectMap : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("subject");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("id_subject");
            builder.Property(e => e.Name).HasColumnName("name");
            builder.Property(e => e.Email).HasColumnName("email");
            builder.Property(e => e.StreetAddress).HasColumnName("street_address");
            builder.Property(e => e.City).HasColumnName("city");
            builder.Property(e => e.PostCode).HasColumnName("post_code");
            builder.Property(e => e.Country).HasColumnName("country");
        }
    }
}
