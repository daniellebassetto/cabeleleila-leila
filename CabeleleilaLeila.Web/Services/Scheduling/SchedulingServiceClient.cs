using CabeleleilaLeila.Arguments;

namespace CabeleleilaLeila.Web.Services;

public class SchedulingServiceClient(IHttpClientFactory factory) : BaseServiceClient<InputCreateScheduling, InputUpdateScheduling, OutputScheduling, InputIdentifierScheduling>(factory), ISchedulingServiceClient
{
    public async Task<BaseServiceClientResponse<bool>> Confirm(long id)
    {
        return await HandleRequestAsync<bool>(HttpMethod.Post, $"{_nameService}/Confirm/{id}", null);
    }
}