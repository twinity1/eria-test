using System.Collections.Generic;
using System.Linq;
using EriaTest.Data.Entities;

namespace EriaTest.Data.Repositories
{
    public class AssigmentTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AssigmentTypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<AssigmentType> GetAll()
        {
            return _dbContext.AssigmentTypes.ToList();
        }
    }
}