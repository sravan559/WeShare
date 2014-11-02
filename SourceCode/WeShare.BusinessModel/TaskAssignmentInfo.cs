using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeShare.BusinessModel
{
    public class TaskAssignmentInfo:TaskInfo
    {
        /// <summary>
        /// Property for ID of the Task
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// Property for Title of the Task
        /// </summary>
        public string TaskTitle { get; set; }

        /// <summary>
        /// Property for description of the Task
        /// </summary>
        public string TaskDescription { get; set; }

        /// <summary>
        /// Property for the Username assigned to the Task
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Property for UserID assigned to the Task
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Property for DueDate of the Task
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Property for Status of the Task
        /// </summary>
        public string Status { get; set; }

    }
}
