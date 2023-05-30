using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolRegister.DAL.EF;
using SchoolRegister.Model.DataModels;
using SchoolRegister.Services.Interfaces;
using SchoolRegister.ViewModels.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Services.ConcreteServices
{
    public class StudentService : BaseService, IStudentService
    {
        public StudentService(ApplicationDbContext dbContext,
            IMapper mapper,
            ILogger logger) : base(dbContext, mapper, logger) { }

        public IEnumerable<StudentVm> GetStudents(Expression<Func<Student, bool>> filterPredicate = null)
        {
            var studentsEntities = dbContext.Users.OfType<Student>().AsQueryable();
            if (filterPredicate != null)
                studentsEntities = studentsEntities.Where(filterPredicate);
            var studentsVm = Mapper.Map<IEnumerable<StudentVm>>(studentsEntities);
            return studentsVm;
        }

        public StudentVm GetStudent(Expression<Func<Student, bool>> filterPredicate)
        {
            if (filterPredicate == null) throw new ArgumentNullException($"filterPredicate is null");
            var studentEntity = dbContext.Users.OfType<Student>().FirstOrDefault(filterPredicate);
            var studentVm = Mapper.Map<StudentVm>(studentEntity);
            return studentVm;
        }

    }
}
