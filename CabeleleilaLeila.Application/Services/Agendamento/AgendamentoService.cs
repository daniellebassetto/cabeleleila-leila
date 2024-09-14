using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Domain.Entities;
using CabeleleilaLeila.Domain.Interfaces;
using CabeleleilaLeila.Application.Interfaces;

namespace CabeleleilaLeila.Application.Services;

public class AgendamentoService(IUnitOfWork unitOfWork) : BaseService<IAgendamentoRepository, InputCreateAgendamento, InputUpdateAgendamento, Agendamento, OutputAgendamento, InputIdentifierAgendamento>(unitOfWork), IAgendamentoService
{ }