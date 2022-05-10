using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiseIslemleri.Entity.Configurations
{
    public class BillConfigurations : AbstractValidator<Bill>, IEntityTypeConfiguration<Bill>
    {
        public BillConfigurations()
        {

        }
      

        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(p => p.BillId);
            builder.Property(p => p.BillId).UseIdentityColumn();
            builder.HasOne<Subscriptions>(x => x.Subscriptions).WithMany(y => y.Bills).HasForeignKey(x => x.SubscriptionId);

            builder.ToTable("Bills");
        }
    }
}
