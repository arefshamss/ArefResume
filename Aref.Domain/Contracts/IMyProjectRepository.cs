using Aref.Domain.Contracts.Generics;
using Aref.Domain.Models.MyProject;

namespace Aref.Domain.Contracts;

public interface IMyProjectRepository : IEfRepository<MyProject, short>;