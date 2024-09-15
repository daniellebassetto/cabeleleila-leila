using CabeleleilaLeila.Application.Interfaces;
using CabeleleilaLeila.Arguments;
using CabeleleilaLeila.Domain.Entities;
using CabeleleilaLeila.Domain.Interfaces;

namespace CabeleleilaLeila.Application.Services;

public class ScheduledService(IUnitOfWork unitOfWork) : BaseService<IScheduledRepository, InputCreateScheduled, InputUpdateScheduled, Scheduled, OutputScheduled, InputIdentifierScheduled>(unitOfWork), IScheduledService
{
    public override OutputScheduled Create(InputCreateScheduled inputCreate)
    {
        Scheduled? originalScheduled = _repository!.GetByIdentifier(new InputIdentifierScheduled(inputCreate.DateTime!.Value));

        if (originalScheduled is not null)
            throw new InvalidOperationException($"Horário '{inputCreate.DateTime.Value}' indisponível para agendamento.");

        Scheduled scheduled = FromInputCreateToEntity(inputCreate).SetProperty(nameof(Scheduled.Status), EnumStatusScheduled.WaitingConfirmation);
        var entity = _repository.Create(scheduled) ?? throw new InvalidOperationException("Falha ao criar o agendamento.");
        _unitOfWork!.Commit();

        return FromEntityToOutput(entity);
    }

    public override OutputScheduled Update(long id, InputUpdateScheduled inputUpdate)
    {
        Scheduled? originalScheduled = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException($"Não foi encontrado nenhum agendamento correspondente a este Id.");

        Scheduled scheduled = UpdateEntity(originalScheduled, inputUpdate) ?? throw new Exception("Problemas para realizar atualização");
        var entity = _repository!.Update(scheduled) ?? throw new InvalidOperationException("Falha ao atualizar o agendamento.");
        _unitOfWork!.Commit();

        return FromEntityToOutput(entity);
    }

    public bool Cancel(long id)
    {
        Scheduled? originalScheduled = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException($"Não foi encontrado nenhum agendamento correspondente a este Id.");

        _repository!.Update(originalScheduled.SetProperty(nameof(Scheduled.Status), EnumStatusScheduled.Canceled));
        _unitOfWork!.Commit();
        return true;
    }

    public bool Confirm(long id)
    {
        Scheduled? originalScheduled = _repository!.Get(x => x.Id == id) ?? throw new KeyNotFoundException($"Não foi encontrado nenhum agendamento correspondente a este Id.");

        _repository!.Update(originalScheduled.SetProperty(nameof(Scheduled.Status), EnumStatusScheduled.Confirmed));
        _unitOfWork!.Commit();
        return true;
    }
}