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
    public class RoleConfiguration : AbstractValidator<Role>, IEntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
        }


        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(p => p.RoleId);
            builder.Property(p => p.RoleId).UseIdentityColumn();
            builder.Property(p => p.RoleName).IsRequired();
            builder.HasIndex(p => p.RoleName).IsUnique();
            builder.ToTable("Roles");
        }
    }
}
