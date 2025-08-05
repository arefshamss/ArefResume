using Aref.Domain.Models.MySkill;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aref.Infra.Data.Configuration.MySkillConfigs;


    public class MySkillConfig: IEntityTypeConfiguration<MySkill>
    {
        public void Configure(EntityTypeBuilder<MySkill> builder)
        {
            #region Key

            builder.HasKey(c => c.Id);

            #endregion

            #region Validations

            builder.Property(c => c.Title)
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(c => c.SubTitle)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(c => c.ImageUrl)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(x => x.Percent)
                .IsRequired();
            
            builder.Property(c => c.DisplayPriority)
                .IsRequired();
            #endregion
        }
    }