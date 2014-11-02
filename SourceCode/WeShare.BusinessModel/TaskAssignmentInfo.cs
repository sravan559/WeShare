using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeShare.BusinessModel
{
    public class TaskAssignmentInfo:TaskInfo
    {
        public int TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }

    }
}
