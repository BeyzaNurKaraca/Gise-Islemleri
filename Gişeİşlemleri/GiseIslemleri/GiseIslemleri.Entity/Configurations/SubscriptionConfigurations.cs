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
    public class SubscriptionsConfiguration : AbstractValidator<Subscriptions>, IEntityTypeConfiguration<Subscriptions>
    {
        public SubscriptionsConfiguration()
        {

        }
    
        public void Configure(EntityTypeBuilder<Subscriptions> builder)
        {

            builder.HasKey(s => s.SubscriptionsId);
            builder.Property(s => s.SubscriptionsId).UseIdentityColumn();
            builder.Property(s => s.CompanyName).IsRequired();
            builder.Property(s => s.Deposit).IsRequired();
            builder.HasOne<User>(x=>x.User).WithMany(y=>y.Subscriptions).HasForeignKey(x=>x.UserId);
            builder.ToTable("Subscriptions");
        }
    }
}
