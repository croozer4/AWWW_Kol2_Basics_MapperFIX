using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class SubjectGroup
    {
        public SubjectGroup() { }
        public int? Id { get; set; }
        public virtual Subject Subject { get; set; }
        public int? SubjectId { get; set; }
        public virtual Group Group { get; set; }
        public int? GroupId { get; set; }
    }
}
