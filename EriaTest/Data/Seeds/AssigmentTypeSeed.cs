using System.Collections.Generic;
using EriaTest.Data.Entities;

namespace EriaTest.Data.Seeds
{
    public class AssigmentTypeSeed
    {
        public ICollection<AssigmentType> Seed()
        {
            return new List<AssigmentType>()
            {
                new AssigmentType
                {
                    Id = 1,
                    Title = "Programming", 
                },
                new AssigmentType
                {
                    Id = 2,
                    Title = "Project management", 
                },
                new AssigmentType
                {
                    Id = 3,
                    Title = "Etc.", 
                },
            };
        }
    }
}