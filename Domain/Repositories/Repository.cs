namespace Domain.Repositories;

public sealed class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private AppDbContext Context { get; }

    private DbSet<TEntity> Set => Context.Set<TEntity>();

    public Repository(AppDbContext dbContext)
    {
        Context = dbContext;
    }

    public IQueryable<TEntity> Query => Set;

    public TEntity Find(params object[] keys)
    {
        return Set.Find(keys);
        
    }

    public void Insert(TEntity entity)
    {
        var entry = Context.Entry(entity);
        if (entry.State == EntityState.Detached)
            Set.Add(entity);

        Context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        var entry = Context.Entry(entity);
        if (entry.State == EntityState.Detached)
            Set.Attach(entity);
        Set.Remove(entity);

        Context.SaveChanges();

    }

    public void Update(TEntity entity)
    {
        var entry = Context.Entry(entity);
        if (entry.State == EntityState.Detached)
            Set.Attach(entity);
        entry.State = EntityState.Modified;

        Context.SaveChanges();
    }
}