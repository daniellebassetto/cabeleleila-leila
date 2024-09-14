namespace CabeleleilaLeila.Web.Services;

public class BaseResponseApi<TTypeResult>
{
    public TTypeResult? Result { get; set; }
    public string? ErrorMessage { get; set; }
}