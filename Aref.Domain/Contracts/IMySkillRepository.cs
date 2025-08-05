using Aref.Domain.Contracts.Generics;
using Aref.Domain.Models.MySkill;

namespace Aref.Domain.Contracts;

public interface IMySkillRepository : IEfRepository<MySkill, short>;