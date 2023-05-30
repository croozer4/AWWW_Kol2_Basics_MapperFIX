using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolRegister.ViewModels.VM
{
    public class SendEmailToParentVm
    {
        public int SenderId { get; set; }
        public int StudentId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
