using Aref.Domain.Contracts;
using Aref.Domain.Models.CounterBox;
using Aref.Infra.Data.Context;
using Aref.Infra.Data.Repositories.Generics;

namespace Aref.Infra.Data.Repositories;

public class CounterBoxRepository(ArefContext context) : EfRepository<CounterBox, short>(context), ICounterBoxRepository;