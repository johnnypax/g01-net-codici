namespace G01_07_EF_CF_OTM.Repos
{
    public interface IRepoScrittura<T>
    {
        bool Create(T entity);
        bool Delete(T entity);
        bool Update(T entity);

    }
}
