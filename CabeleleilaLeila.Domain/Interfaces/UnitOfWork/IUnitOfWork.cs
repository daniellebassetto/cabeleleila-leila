using Microsoft.EntityFrameworkCore.Storage;
using CabeleleilaLeila.Domain.Entities;

namespace CabeleleilaLeila.Domain.Interfaces;

public interface IUnitOfWork
{
    TIBaseRepository GetRepository<TIBaseRepository, TEntity, TInputIdentifier>()
        where TIBaseRepository : IBaseRepository<TEntity, TInputIdentifier>
        where TEntity : BaseEntity<TEntity>
        where TInputIdentifier : class;
    void Commit();
}