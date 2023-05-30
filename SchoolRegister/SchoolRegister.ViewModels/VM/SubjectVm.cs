using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.ViewModels.VM
{
    public class SubjectVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<GroupVm> Groups { get; set; } = null!;
        public string TeacherName { get; set; } = null!;
        public int? TeacherId { get; set; }
    }
}
