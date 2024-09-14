namespace CabeleleilaLeila.Web.Services;

public class BaseServiceClientResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? ErrorMessage { get; set; }

    public BaseServiceClientResponse() { }

    public BaseServiceClientResponse(bool success, T? data, string? errorMessage)
    {
        Success = success;
        Data = data;
        ErrorMessage = errorMessage;
    }
}