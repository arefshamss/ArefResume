using Aref.Domain.Contracts.Generics;
using Aref.Domain.Models.User;

namespace Aref.Domain.Contracts;

public interface IUserRepository : IEfRepository<User>;

