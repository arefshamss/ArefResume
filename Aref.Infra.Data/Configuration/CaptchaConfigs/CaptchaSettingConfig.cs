using Aref.Domain.Models.Captcha;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aref.Infra.Data.Configuration.CaptchaConfigs
{
    public class CaptchaSettingConfig : IEntityTypeConfiguration<CaptchaSetting>
    {
        public void Configure(EntityTypeBuilder<CaptchaSetting> builder)
        {
            #region Key

            builder.HasKey(c => c.Id);

            #endregion
        }
    }
}
