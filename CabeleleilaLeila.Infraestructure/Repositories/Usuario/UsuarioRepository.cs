using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Domain.Entities;
using CabeleleilaLeila.Domain.Interfaces;

namespace CabeleleilaLeila.Infraestructure.Repositories;

public class UsuarioRepository(CabeleleilaLeilaContext context) : BaseRepository<Usuario, InputIdentifierUsuario>(context), IUsuarioRepository { }