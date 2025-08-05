using Aref.Domain.Models.MyService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aref.Infra.Data.Configuration.MyServiceConfigs;

public class ServiceConfig: IEntityTypeConfiguration<MyService>
{
    public void Configure(EntityTypeBuilder<MyService> builder)
    {
        #region Key

        builder.HasKey(c => c.Id);

        #endregion

        #region Validations

        builder.Property(c => c.Title)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(c => c.IconName)
            .HasMaxLength(300)
            .IsRequired();
        
        builder.Property(c => c.Description)
            .HasMaxLength(600)
            .IsRequired(false);
        
        builder.Property(c => c.DisplayPriority)
            .IsRequired();

        #endregion
    }
}