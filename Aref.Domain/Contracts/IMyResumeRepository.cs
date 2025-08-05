using Aref.Domain.Contracts.Generics;
using Aref.Domain.Models.MyResume;

namespace Aref.Domain.Contracts;

public interface IMyResumeRepository : IEfRepository<MyResume, short>;
