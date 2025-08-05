using Aref.Domain.Models.PageContent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aref.Infra.Data.Configuration.PageContentConfigs;

public class PageContentConfig : IEntityTypeConfiguration<PageContent>
{
    public void Configure(EntityTypeBuilder<PageContent> builder)
    {
        #region Key

        builder.HasKey(x => x.Id);
        
        #endregion

        #region Properties

        builder.Property(x => x.Description)
            .IsRequired(false)
            .HasMaxLength(10000);
        
        
        builder.Property(x => x.Title)
            .IsRequired(false)
            .HasMaxLength(500);

        #endregion
    }
}