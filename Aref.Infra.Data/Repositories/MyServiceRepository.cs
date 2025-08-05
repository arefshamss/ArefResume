using Aref.Domain.Contracts;
using Aref.Domain.Models.MyService;
using Aref.Infra.Data.Context;
using Aref.Infra.Data.Repositories.Generics;

namespace Aref.Infra.Data.Repositories;

public class MyServiceRepository(ArefContext context) : EfRepository<MyService, short>(context), IMyServiceRepository;