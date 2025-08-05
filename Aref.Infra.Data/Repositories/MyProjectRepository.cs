using Aref.Domain.Contracts;
using Aref.Domain.Models.MyProject;
using Aref.Infra.Data.Context;
using Aref.Infra.Data.Repositories.Generics;

namespace Aref.Infra.Data.Repositories;

public class MyProjectRepository(ArefContext context) : EfRepository<MyProject, short>(context), IMyProjectRepository;