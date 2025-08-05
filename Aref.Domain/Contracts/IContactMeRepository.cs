using Aref.Domain.Contracts.Generics;
using Aref.Domain.Models.ContactMe;

namespace Aref.Domain.Contracts;

public interface IContactMeRepository : IEfRepository<ContactMe, short>;