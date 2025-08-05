using Aref.Domain.Models.SocialMedia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aref.Infra.Data.Configuration.SocialMediaConfigs;

public class SocialMediaConfig: IEntityTypeConfiguration<SocialMedia>
{
    public void Configure(EntityTypeBuilder<SocialMedia> builder)
    {
        #region Key

        builder.HasKey(c => c.Id);

        #endregion

        #region Validations

        builder.Property(c => c.Title)
            .HasMaxLength(100)
            .IsRequired();
            
        builder.Property(c => c.Link)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(c => c.IconName)
            .HasMaxLength(200)
            .IsRequired();        
        
        builder.Property(c => c.IsVisible)
            .IsRequired();
        
        builder.Property(c => c.DisplayPriority)
            .IsRequired();

        #endregion
    }
}