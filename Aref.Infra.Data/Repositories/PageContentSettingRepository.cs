using Aref.Domain.Contracts;
using Aref.Domain.Models.PageContent;
using Aref.Infra.Data.Context;
using Aref.Infra.Data.Repositories.Generics;

namespace Aref.Infra.Data.Repositories;

public class PageContentSettingRepository(ArefContext context) : EfRepository<PageContentSetting, short>(context), IPageContentSettingRepository;