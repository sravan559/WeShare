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
        /// Property for Points allocated to that Task
        /// </summary>
        public int PointsAllocated { get; set; }

        /// <summary>
        /// Property for Type of the Task
        /// </summary>
        public string TaskType { get; set; }

        /// <summary>
        /// Property to know if the Task is recursive
        /// </summary>
        public bool IsTaskRecursive { get; set; }

        /// <summary>
        /// Property to know if the Task is recursive
        /// </summary>
        public string GroupName { get; set; }
        

    }


}
