using CabeleleilaLeila.Arguments;

namespace CabeleleilaLeila.Web.Services;

public interface ISchedulingServiceClient : IBaseServiceClient<InputCreateScheduling, InputUpdateScheduling, OutputScheduling, InputIdentifierScheduling>
{
    Task<BaseServiceClientResponse<bool>> Confirm(long id);
}