using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeShare.BusinessModel
{
    public class UserInfo
    {
        /// <summary>
        /// Property for User ID (Email Address) of the User
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Property to store and retrieve the full name (FirstName,LastName) of the User
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Property for First Name
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Property for Last Name of the user
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Property for Contact Number
        /// </summary>
        public string ContactNumber { get; set; }
        
        /// <summary>
        /// Property for Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Minimum points for User
        /// </summary>
        public double WeeklyPoints { get; set; }
    }
}
