using Aref.Domain.Contracts;
using Aref.Domain.Models.MySkill;
using Aref.Infra.Data.Context;
using Aref.Infra.Data.Repositories.Generics;

namespace Aref.Infra.Data.Repositories;

public class MySkillRepository(ArefContext context) : EfRepository<MySkill, short>(context), IMySkillRepository;