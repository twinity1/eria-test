using System;
using System.Linq;
using EriaTest.Data.Entities;
using EriaTest.Models;

namespace EriaTest.Services
{
    public class AssigmentService
    {
        public void Map(AssigmentViewModel vm, Assigment assigment)
        {
            assigment.Title = vm.Title;
            assigment.Start = vm.Start;
            assigment.End = vm.End;
            assigment.Type = vm.AssigmentTypes.FirstOrDefault(x => x.Id == vm.TaskTypeId) ??
                             throw new ArgumentException("Task type could not be found.");

        }
    }
}