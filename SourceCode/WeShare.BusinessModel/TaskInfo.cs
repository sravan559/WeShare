using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeShare.BusinessModel
{
    public class TaskInfo
    {
        public int TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public int PointsAllocated { get; set; }
        public string TaskType { get; set; }
        public string TaskRecursive { get; set; }
    }


}
