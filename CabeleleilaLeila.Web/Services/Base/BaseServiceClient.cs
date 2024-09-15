using Newtonsoft.Json;

namespace CabeleleilaLeila.Web.Services;

public class BaseServiceClient<TInputCreate, TInputUpdate, TOutput, TInputIdentifier>(IHttpClientFactory factory) : IBaseServiceClient<TInputCreate, TInputUpdate, TOutput, TInputIdentifier>
{
    private readonly HttpClient _httpClient = factory.CreateClient("API");
    protected readonly string _nameService = typeof(TOutput).Name[6..];

    public async Task<BaseServiceClientResponse<ICollection<TOutput>>> GetAll()
    {
        return await HandleRequestAsync<ICollection<TOutput>>(HttpMethod.Get, $"{_nameService}", null);
    }

    public async Task<BaseServiceClientResponse<TOutput>> GetById(long id)
    {
        return await HandleRequestAsync<TOutput>(HttpMethod.Get, $"{_nameService}/{id}", null);
    }

    public async Task<BaseServiceClientResponse<TOutput>> GetByIdentifier(TInputIdentifier inputIdentifier)
    {
        return await HandleRequestAsync<TOutput>(HttpMethod.Post, $"{_nameService}/GetByIdentifier", inputIdentifier);
    }

    public async Task<BaseServiceClientResponse<bool>> Create(TInputCreate inputCreate)
    {
        return await HandleRequestAsync<bool>(HttpMethod.Post, $"{_nameService}", inputCreate);
    }

    public async Task<BaseServiceClientResponse<bool>> Update(long id, TInputUpdate inputUpdate)
    {
        return await HandleRequestAsync<bool>(HttpMethod.Put, $"{_nameService}/{id}", inputUpdate);
    }

    public async Task<BaseServiceClientResponse<bool>> Delete(long id)
    {
        return await HandleRequestAsync<bool>(HttpMethod.Delete, $"{_nameService}/{id}", null);
    }

    protected async Task<BaseServiceClientResponse<TResponse>> HandleRequestAsync<TResponse>(HttpMethod method, string requestUri, object? requestData)
    {
        try
        {
            HttpResponseMessage response = method.Method switch
            {
                "GET" => await _httpClient.GetAsync($"api/{requestUri}"),
                "POST" => await _httpClient.PostAsJsonAsync($"api/{requestUri}", requestData),
                "PUT" => await _httpClient.PutAsJsonAsync($"api/{requestUri}", requestData),
                "DELETE" => await _httpClient.DeleteAsync($"api/{requestUri}"),
                _ => throw new NotSupportedException($"HTTP method '{method.Method}' is not supported."),
            };

            var responseData = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<BaseResponseApi<TResponse>>(responseData);
                return new BaseServiceClientResponse<TResponse>(true, result!.Result, null);
            }
            else
            {
                var errorResult = JsonConvert.DeserializeObject<BaseResponseApi<TResponse>>(responseData);
                return new BaseServiceClientResponse<TResponse>(false, default, errorResult?.ErrorMessage);
            }
        }
        catch (HttpRequestException ex)
        {
            return new BaseServiceClientResponse<TResponse>(false, default, ex.Message);
        }
    }
}