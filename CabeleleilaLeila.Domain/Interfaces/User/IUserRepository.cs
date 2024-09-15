using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Domain.Entities;

namespace CabeleleilaLeila.Domain.Interfaces;

public interface IUserRepository : IBaseRepository<User, InputIdentifierUser> { }