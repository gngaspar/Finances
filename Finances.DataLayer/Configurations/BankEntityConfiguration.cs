using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.Domain.Banking;

namespace Finances.DataLayer.Configurations
{
    public class BankEntityConfiguration : EntityTypeConfiguration<BankEntity>
    {
        public BankEntityConfiguration()
        {
            this.HasKey(p => p.Code).ToTable("Banks");
            this.Property(p => p.Name).IsRequired();
        }
    }
}
