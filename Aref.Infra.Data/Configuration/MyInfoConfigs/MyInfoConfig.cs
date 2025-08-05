using Aref.Domain.Models.MyInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aref.Infra.Data.Configuration.MyInfoConfigs;

public class MyInfoConfig: IEntityTypeConfiguration<MyInfo>
{
    public void Configure(EntityTypeBuilder<MyInfo> builder)
    {
        #region Key

        builder.HasKey(c => c.Id);

        #endregion

        #region Validations
                
        builder.Property(c => c.FullName)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(c => c.Title)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(c => c.Mobile)
            .HasMaxLength(20)
            .IsRequired();   
        
        builder.Property(c => c.Email)
            .HasMaxLength(100)
            .IsRequired();  

        builder.Property(c => c.ImageUrl)
            .HasMaxLength(300)
            .IsRequired();
        
        builder.Property(c => c.CvUrl)
            .HasMaxLength(300)
            .IsRequired(false);    
        
        builder.Property(c => c.CvVisibility)
            .IsRequired();  
        
        builder.Property(c => c.EmailVisibility)
            .IsRequired();  
        
        builder.Property(c => c.MobileVisibility)
            .IsRequired();   
        
        builder.Property(c => c.TitleVisibility)
            .IsRequired();
        #endregion
    }
}