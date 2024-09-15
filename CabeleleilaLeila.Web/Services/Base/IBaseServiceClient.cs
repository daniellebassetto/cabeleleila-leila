namespace CabeleleilaLeila.Web.Services;

public interface IBaseServiceClient<TInputCreate, TInputUpdate, TOutput, TInputIdentifier>
{
    Task<BaseServiceClientResponse<ICollection<TOutput>>> GetAll();
    Task<BaseServiceClientResponse<TOutput>> GetById(long id);
    Task<BaseServiceClientResponse<TOutput>> GetByIdentifier(TInputIdentifier inputIdentifier);
    Task<BaseServiceClientResponse<TOutput>> Create(TInputCreate inputCreate);
    Task<BaseServiceClientResponse<TOutput>> Update(long id, TInputUpdate inputUpdate);
    Task<BaseServiceClientResponse<bool>> Delete(long id);
}