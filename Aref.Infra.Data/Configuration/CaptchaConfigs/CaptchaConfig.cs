using Aref.Domain.Models.Captcha;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aref.Infra.Data.Configuration.CaptchaConfigs
{
    public class CaptchaConfig : IEntityTypeConfiguration<Captcha>
    {
        public void Configure(EntityTypeBuilder<Captcha> builder)
        {
            #region Key

            builder.HasKey(c => c.Id);

            #endregion

            #region Validate

            builder.Property(c => c.SiteKey).HasMaxLength(450);
            builder.Property(c => c.SecretKey).HasMaxLength(450);

            #endregion
        }
    }
}
