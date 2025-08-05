using Aref.Domain.Contracts.Generics;
using Aref.Domain.Models.CounterBox;

namespace Aref.Domain.Contracts;

public interface ICounterBoxRepository : IEfRepository<CounterBox, short>;