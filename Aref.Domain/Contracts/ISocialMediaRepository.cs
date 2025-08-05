using Aref.Domain.Contracts.Generics;
using Aref.Domain.Models.SocialMedia;

namespace Aref.Domain.Contracts;

public interface ISocialMediaRepository : IEfRepository<SocialMedia,short>
{
    
}