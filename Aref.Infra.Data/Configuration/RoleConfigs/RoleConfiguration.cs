using Aref.Domain.Models.Role;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aref.Infra.Data.Configuration.RoleConfigs;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        #region Key

        builder.HasKey(x => x.Id);

        #endregion

        #region Properties

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        #endregion
    }
}