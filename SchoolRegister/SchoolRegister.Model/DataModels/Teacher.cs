using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Teacher : User
    {
        public Teacher() { }
        public string Title { get; set; }
        public virtual IList<Subject> Subjects { get; set; }
    }
}
