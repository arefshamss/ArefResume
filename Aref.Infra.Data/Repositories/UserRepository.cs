using Aref.Domain.Contracts;
using Aref.Domain.Models.User;
using Aref.Infra.Data.Context;
using Aref.Infra.Data.Repositories.Generics;

namespace Aref.Infra.Data.Repositories;

public class UserRepository(ArefContext context) : EfRepository<User>(context), IUserRepository;