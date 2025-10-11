namespace BootCamp2_6_weekEnd.Repository.Base
{
    public interface IRepository<X> where X : class
    {
        void Create(X entity);
        void Update(X entity);
        void Delete(X entity);
        X GetById(int Id);
        IEnumerable<X> GetAll();

    }
}
