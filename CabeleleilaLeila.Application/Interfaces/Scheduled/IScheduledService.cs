using CabeleleilaLeila.Arguments;

namespace CabeleleilaLeila.Application.Interfaces;

public interface IScheduledService : IBaseService<InputCreateScheduled, InputUpdateScheduled, OutputScheduled, InputIdentifierScheduled>
{
    bool Cancel(long id);
    bool Confirm(long id);
}