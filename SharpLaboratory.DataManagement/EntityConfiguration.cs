using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharpLaboratory.DataManagement.Contracts;

namespace SharpLaboratory.DataManagement;

public abstract class EntityConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
    where TEntity : class, IEntity<TKey>
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(entity => entity.Id);
        ConfigureEntityCustomFields(builder);
    }

    protected abstract void ConfigureEntityCustomFields(EntityTypeBuilder<TEntity> builder);
}