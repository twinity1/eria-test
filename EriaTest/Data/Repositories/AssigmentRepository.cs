using System.Linq;
using System.Threading.Tasks;
using EriaTest.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EriaTest.Data.Repositories
{
    public class AssigmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AssigmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Assigment> GetDataSourceAsNoTracking()
        {
            return _dbContext
                .Assigments
                .AsQueryable()
                .AsNoTracking()
                .Include(x => x.Type);
        }

        public async Task Save(Assigment assigment)
        {
            if (assigment.Id == 0)
            {
                _dbContext.Assigments.Add(assigment);
            }

            await _dbContext.SaveChangesAsync();
        }

        public Assigment? GetById(int id)
        {
            return _dbContext.Assigments.FirstOrDefault(x => x.Id == id);
        }

        public async Task Delete(Assigment entity)
        {
            _dbContext.Assigments.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}