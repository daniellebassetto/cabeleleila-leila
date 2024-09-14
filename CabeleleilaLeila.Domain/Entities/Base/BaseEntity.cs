using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CabeleleilaLeila.Domain.Entities;

public class BaseEntity<TEntity> : BaseSetProperty<TEntity>
    where TEntity : BaseEntity<TEntity>
{
    [Required]
    public virtual long? Id { get; set; }
    public virtual DateTime? DataCadastro { get; set; }
    public virtual DateTime? DataAlteracao { get; set; }

    public TEntity SetCreateData()
    {
        DataCadastro = DateTime.Now;

        return (this as TEntity)!;
    }

    public TEntity SetUpdateData()
    {
        DataAlteracao = DateTime.Now;

        return (this as TEntity)!;
    }
}

public class BaseEntity_0 : BaseEntity<BaseEntity_0> { }