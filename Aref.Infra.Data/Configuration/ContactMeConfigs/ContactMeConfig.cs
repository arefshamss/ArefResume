using Aref.Domain.Models.ContactMe;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aref.Infra.Data.Configuration.ContactMeConfigs;

public class ContactMeConfig:IEntityTypeConfiguration<ContactMe>
{
    public void Configure(EntityTypeBuilder<ContactMe> builder)
    {
        #region Key

        builder.HasKey(s => s.Id);

        #endregion

        #region Validation

        builder.Property(s => s.FullName)
            .IsRequired()
            .HasMaxLength(350);
        
        builder.Property(s => s.Subject)
            .IsRequired(false)
            .HasMaxLength(350);
        
        builder.Property(s => s.Mobile)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(s => s.Email)
            .IsRequired(false)
            .HasMaxLength(50);
        
        builder.Property(s => s.Message)
            .IsRequired()
            .HasMaxLength(1500); 

        #endregion
    }
}