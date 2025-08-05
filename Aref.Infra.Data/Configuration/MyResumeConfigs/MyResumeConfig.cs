using Aref.Domain.Models.MyResume;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aref.Infra.Data.Configuration.MyResumeConfigs;

public class MyResumeConfig : IEntityTypeConfiguration<MyResume>
{
    public void Configure(EntityTypeBuilder<MyResume> builder)
    {
        #region Key

        builder.HasKey(x => x.Id);
        
        #endregion

        #region Properties

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(1000);
        
        builder.Property(x => x.Years)
            .IsRequired()
            .HasMaxLength(50);    
        
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(500);
        
        builder.Property(c => c.DisplayPriority)
            .IsRequired();

        #endregion
    }
}