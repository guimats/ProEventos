using System.Threading.Tasks;

namespace ProEventos.Infrastructure.Repositories.General
{
    public interface IGeneralRepository
    {
        public void Add<T>(T entity) where T : class;
        public void Update<T>(T entity) where T : class;
        public void Delete<T>(T entity) where T : class;
        public void DeleteRange<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();
    }

}
