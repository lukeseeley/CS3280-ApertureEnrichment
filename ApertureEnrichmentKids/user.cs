using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApertureEnrichmentKids
{
    /// <summary>
    /// Stores the Name and Age of a user
    /// </summary>
    public class User
    {
        #region Attributes
        /// <summary>
        /// The user's Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The user's Age
        /// </summary>
        public int Age { get; set; }
        #endregion

        #region Methods
        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }


        #endregion
    }
}
