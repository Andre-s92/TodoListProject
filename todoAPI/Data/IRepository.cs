using System.Threading.Tasks;
using todoAPI.Models;

namespace todoAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //ALUNO
        Task<ToDo[]> GetAllToDoAsync();
        Task<ToDo> GetToDoAsyncById(int Id);
         
    }
}