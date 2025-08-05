using Aref.Domain.Contracts;
using Aref.Domain.Models.Captcha;
using Aref.Infra.Data.Context;
using Aref.Infra.Data.Repositories.Generics;

namespace Aref.Infra.Data.Repositories;

public class CaptchaRepository(ArefContext context) : EfRepository<Captcha, short>(context), ICaptchaRepository
{

}