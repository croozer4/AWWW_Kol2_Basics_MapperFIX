using SchoolRegister.Model.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.ViewModels.VM
{
    public class GradesReportVm
    {
        public string StudentLastName { get; set; }
        public string StudentFirstName { get; set; }
        public string GroupName { get; set; }
        public string ParentName { get; set; }

        public IDictionary<string, List<GradeScale>> StudentGradesPerSubject { get; set; }
    }
}
