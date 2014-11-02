using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeShare.BusinessModel
{
    public class TaskInfo
    {
        /// <summary>
        /// Property for Task ID of the Task
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// Property for Title of the Task
        /// </summary>
        public string TaskTitle { get; set; }

        /// <summary>
        /// Property for Description of the Task
        /// </summary>
        public string TaskDescription { get; set; }

        /// <summary>
        /// Property for Points allocated to that task
        /// </summary>
        public int PointsAllocated { get; set; }
        public string TaskType { get; set; }
        public string TaskRecursive { get; set; }
    }


}
