using CabeleleilaLeila.Application.Interfaces;
using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Domain.Entities;
using CabeleleilaLeila.Domain.Interfaces;

namespace CabeleleilaLeila.Application.Services;

public class SchedulingService(IUnitOfWork unitOfWork) : BaseService<ISchedulingRepository, InputCreateScheduling, InputUpdateScheduling, Scheduling, OutputScheduling, InputIdentifierScheduling>(unitOfWork), ISchedulingService
{
    public override OutputScheduling Create(InputCreateScheduling inputCreate)
    {
        Scheduling? originalScheduling = _repository!.GetByIdentifier(new InputIdentifierScheduling(inputCreate.DateTime!.Value));

        if (originalScheduling is not null)
            throw new InvalidOperationException($"Horário '{inputCreate.DateTime.Value}' indisponível para agendamento.");

        if (inputCreate.DateTime <= DateTime.Now)
            throw new InvalidOperationException($"A data do agendamento não pode ser retroativa.");

        Scheduling Scheduling = FromInputCreateToEntity(inputCreate).SetProperty(nameof(Scheduling.Status), EnumStatusScheduling.WaitingConfirmation);
        var entity = _repository.Create(Scheduling) ?? throw new InvalidOperationException("Falha ao criar o agendamento.");
        _unitOfWork!.Commit();

        return FromEntityToOutput(entity);
    }

    public override OutputScheduling Update(long id, InputUpdateScheduling inputUpdate)
    {
        Scheduling? originalScheduling = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException($"Não foi encontrado nenhum agendamento correspondente a este Id.");

        if (inputUpdate.DateTime <= DateTime.Now)
            throw new InvalidOperationException($"A data do agendamento não pode ser retroativa.");

        Scheduling Scheduling = UpdateEntity(originalScheduling, inputUpdate) ?? throw new Exception("Problemas para realizar atualização");
        var entity = _repository!.Update(Scheduling) ?? throw new InvalidOperationException("Falha ao atualizar o agendamento.");
        _unitOfWork!.Commit();

        return FromEntityToOutput(entity);
    }

    public bool Confirm(long id)
    {
        Scheduling? originalScheduling = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException($"Não foi encontrado nenhum agendamento correspondente a este Id.");

        _repository!.Update(originalScheduling.SetProperty(nameof(Scheduling.Status), EnumStatusScheduling.Confirmed));
        _unitOfWork!.Commit();
        return true;
    }
}