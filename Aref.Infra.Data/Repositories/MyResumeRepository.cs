using Aref.Domain.Contracts;
using Aref.Domain.Models.MyResume;
using Aref.Infra.Data.Context;
using Aref.Infra.Data.Repositories.Generics;

namespace Aref.Infra.Data.Repositories;

public class MyResumeRepository(ArefContext context) : EfRepository<MyResume, short>(context), IMyResumeRepository;