using Aref.Domain.Contracts.Generics;
using Aref.Domain.Models.MyService;

namespace Aref.Domain.Contracts;

public interface IMyServiceRepository : IEfRepository<MyService, short>;