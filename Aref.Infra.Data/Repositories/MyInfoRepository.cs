using Aref.Domain.Contracts;
using Aref.Domain.Models.MyInfo;
using Aref.Infra.Data.Context;
using Aref.Infra.Data.Repositories.Generics;

namespace Aref.Infra.Data.Repositories;

public class MyInfoRepository(ArefContext context) : EfRepository<MyInfo, short>(context), IMyInfoRepository;