using Aref.Domain.Contracts;
using Aref.Domain.Models.Role;
using Aref.Infra.Data.Context;
using Aref.Infra.Data.Repositories.Generics;

namespace Aref.Infra.Data.Repositories;

public class UserRoleMappingRepository(ArefContext context) : EfRepository<UserRoleMapping>(context), IUserRoleMappingRepository;