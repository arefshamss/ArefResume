using Aref.Domain.Contracts.Generics;
using Aref.Domain.Models.MyInfo;

namespace Aref.Domain.Contracts;

public interface IMyInfoRepository : IEfRepository<MyInfo, short>;