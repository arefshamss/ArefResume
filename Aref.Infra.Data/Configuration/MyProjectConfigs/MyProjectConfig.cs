using Aref.Domain.Models.MyProject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aref.Infra.Data.Configuration.MyProjectConfigs;

public class MyProjectConfig: IEntityTypeConfiguration<MyProject>
{
    public void Configure(EntityTypeBuilder<MyProject> builder)
    {
        #region Key

        builder.HasKey(c => c.Id);

        #endregion

        #region Validations

        builder.Property(c => c.Title)
            .HasMaxLength(300)
            .IsRequired();
            
        builder.Property(c => c.Link)
            .HasMaxLength(300)
            .IsRequired();       
        
        builder.Property(c => c.SecondLink)
            .HasMaxLength(300)
            .IsRequired(false);     
        
        builder.Property(c => c.LinkButtonTitle)
            .HasMaxLength(20)
            .IsRequired();  
        
        builder.Property(c => c.SecondLinkButtonTitle)
            .HasMaxLength(20)
            .IsRequired(false);    
        
        builder.Property(c => c.Developer)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.ImageUrl)
            .HasMaxLength(300)
            .IsRequired();
        
        builder.Property(c => c.DisplayPriority)
            .IsRequired();

        #endregion
    }
}