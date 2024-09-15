using CabeleleilaLeila.Arguments;

namespace CabeleleilaLeila.Web.Services;

public interface ISchedulingServiceClient : IBaseServiceClient<InputCreateScheduling, InputUpdateScheduling, OutputScheduling, InputIdentifierScheduling>
{
    Task<BaseServiceClientResponse<bool>> Cancel(long id);
    Task<BaseServiceClientResponse<bool>> Confirm(long id);
}