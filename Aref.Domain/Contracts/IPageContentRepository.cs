using Aref.Domain.Contracts.Generics;
using Aref.Domain.Models.PageContent;

namespace Aref.Domain.Contracts;

public interface IPageContentRepository : IEfRepository<PageContent, short>
{
}