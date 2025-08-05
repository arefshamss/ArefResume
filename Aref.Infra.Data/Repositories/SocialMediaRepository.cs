using Aref.Domain.Contracts;
using Aref.Domain.Models.SocialMedia;
using Aref.Infra.Data.Context;
using Aref.Infra.Data.Repositories.Generics;

namespace Aref.Infra.Data.Repositories;

public class SocialMediaRepository(ArefContext context) : EfRepository<SocialMedia,short>(context), ISocialMediaRepository
{
    
}