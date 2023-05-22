using Domain;
using Infraestructure.ModelMaps;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MyConnection"));
        }

        public DbSet<InvoiceStatus> InvoiceStatuses { get; set; }
        public DbSet<PaymentTerm> PaymentTerms { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new InvoiceStatusMap());
            modelBuilder.ApplyConfiguration(new PaymentTermMap());
            modelBuilder.ApplyConfiguration(new InvoiceItemMap());
            modelBuilder.ApplyConfiguration(new SubjectMap());
            modelBuilder.ApplyConfiguration(new InvoiceMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
