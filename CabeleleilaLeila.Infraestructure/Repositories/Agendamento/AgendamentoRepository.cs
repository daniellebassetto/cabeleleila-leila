using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Domain.Entities;
using CabeleleilaLeila.Domain.Interfaces;

namespace CabeleleilaLeila.Infraestructure.Repositories;

public class AgendamentoRepository(CabeleleilaLeilaContext context) : BaseRepository<Agendamento, InputIdentifierAgendamento>(context), IAgendamentoRepository { }