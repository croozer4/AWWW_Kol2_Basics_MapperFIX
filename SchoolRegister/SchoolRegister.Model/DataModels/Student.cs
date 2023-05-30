using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Student : User
    {
        public Student() { }
        public virtual Group Group { get; set; }
        public int? GroupId { get; set; }
        public virtual IList<Grade> Grades { get; set; }
        public virtual Parent Parent { get; set; }
        public int? ParentId { get; set; }
        [NotMapped]
        public double AverageGrade =>
            Grades.Any() ? Grades.Average(x => (double)x.GradeValue) : 0;
        [NotMapped]
        public IDictionary<string, double> AverageGradePerSubject =>
            Grades.GroupBy(x => x.Subject.Name)
                .ToDictionary(x => x.Key, x => x.Average(y => (double)y.GradeValue));
        [NotMapped]
        public IDictionary<string,List<GradeScale>> GradesPerSubject => 
            Grades.GroupBy(x => x.Subject.Name)
                .ToDictionary(x => x.Key, x => x.Select(y => y.GradeValue).ToList());
    }
}
