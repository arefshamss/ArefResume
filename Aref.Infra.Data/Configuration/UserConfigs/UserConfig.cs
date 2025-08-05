using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aref.Infra.Data.Configuration.UserConfigs
{
    public class UserConfig : IEntityTypeConfiguration<Domain.Models.User.User>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.User.User> builder)
        {
            #region Key

            builder.HasKey(x => x.Id);

            #endregion

            #region Validations

            builder.Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.Mobile)
                .HasMaxLength(11)
                .IsRequired();
            
            builder.Property(x => x.Mobile2)
                .HasMaxLength(11)
                .IsRequired(false);

            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.AvatarImageName)
                .HasMaxLength(150)
                .IsRequired(false);
            
            builder.Property(x => x.Notes)
                .HasMaxLength(400)
                .IsRequired(false);  
            
            builder.Property(x => x.Address)
                .HasMaxLength(400)
                .IsRequired(false);

            #endregion
        }
    }
}
