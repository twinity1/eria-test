using System;

namespace EriaTest.Data.Entities
{
    public class Assigment
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public DateTime Start { get; set; }
        
        public DateTime End { get; set; }
        
        public AssigmentType Type { get; set; }
    }
}