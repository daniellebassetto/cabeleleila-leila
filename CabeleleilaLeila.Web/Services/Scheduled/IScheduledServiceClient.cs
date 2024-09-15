using CabeleleilaLeila.Arguments;

namespace CabeleleilaLeila.Web.Services;

public interface IScheduledServiceClient : IBaseServiceClient<InputCreateScheduled, InputUpdateScheduled, OutputScheduled, InputIdentifierScheduled> 
{
    Task<BaseServiceClientResponse<bool>> Cancel(long id);
    Task<BaseServiceClientResponse<bool>> Confirm(long id);
}