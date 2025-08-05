using Aref.Domain.Contracts;
using Aref.Domain.Models.ContactMe;
using Aref.Infra.Data.Context;
using Aref.Infra.Data.Repositories.Generics;

namespace Aref.Infra.Data.Repositories;

public class ContactMeRepository(ArefContext context) : EfRepository<ContactMe,short>(context) , IContactMeRepository;