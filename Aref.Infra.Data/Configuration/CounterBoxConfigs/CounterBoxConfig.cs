using Aref.Domain.Models.CounterBox;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aref.Infra.Data.Configuration.CounterBoxConfigs;

public class CounterBoxBoxConfig : IEntityTypeConfiguration<CounterBox>
{
    public void Configure(EntityTypeBuilder<CounterBox> builder)
    {
        #region Key

        builder.HasKey(c => c.Id);

        #endregion

        #region Validations

        builder.Property(c => c.Count)
            .IsRequired();
        
        builder.Property(c => c.Title)
            .HasMaxLength(50)
            .IsRequired();  
        
        builder.Property(c => c.DisplayPriority)
            .IsRequired();

        #endregion
    }
}