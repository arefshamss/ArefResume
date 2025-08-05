using Aref.Domain.Contracts.Generics;
using Aref.Domain.Models.Captcha;

namespace Aref.Domain.Contracts;

public interface ICaptchaRepository : IEfRepository<Captcha, short>
{

}