using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todoAPI.Models;

namespace todoAPI.Data
{
    public class Repository : IRepository
    { 
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<ToDo[]> GetAllToDoAsync()
        {
            IQueryable<ToDo> query = _context.ToDos;

          

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }
        public async Task<ToDo> GetToDoAsyncById(int Id)
        {
            IQueryable<ToDo> query = _context.ToDos;

          

            query = query.AsNoTracking()
                         .OrderBy(aluno => aluno.Id)
                         .Where(aluno => aluno.Id == Id);

            return await query.FirstOrDefaultAsync();
        }
 
    }
}