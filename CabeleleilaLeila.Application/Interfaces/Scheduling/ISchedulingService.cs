using CabeleleilaLeila.Arguments;

namespace CabeleleilaLeila.Application.Interfaces;

public interface ISchedulingService : IBaseService<InputCreateScheduling, InputUpdateScheduling, OutputScheduling, InputIdentifierScheduling>
{
    bool Confirm(long id);
}