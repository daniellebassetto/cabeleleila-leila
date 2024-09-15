using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Domain.Entities;
using CabeleleilaLeila.Domain.Interfaces;

namespace CabeleleilaLeila.Infraestructure.Repositories;

public class UserRepository(CabeleleilaLeilaContext context) : BaseRepository<User, InputIdentifierUser>(context), IUserRepository { }