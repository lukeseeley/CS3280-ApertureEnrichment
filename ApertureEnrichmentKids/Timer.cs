using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApertureEnrichmentKids
{
    /// <summary>
    /// A class for handling the UI timer tracking
    /// </summary>
    class Timer
    {
        #region Attributes
        /// <summary>
        /// An integer representation of the seconds past
        /// </summary>
        private int sec;

        /// <summary>
        /// An integer representation of the minutes past
        /// </summary>
        private int min;

        /// <summary>
        /// A string representation of the timer. 
        /// </summary>
        public string Time { get { return String.Format("{0}:{1}", min.ToString(), sec.ToString().PadLeft(2, '0')); } }

        #endregion

        #region Methods
        /// <summary>
        /// Timer constructor
        /// </summary>
        public Timer()
        {
            sec = 0;
            min = 0;
        }

        public void timeIncrement()
        {
            if (sec >= 59)
            {
                min++;
                sec = 0;
            }
            else
            {
                sec++;
            }
        }

        #endregion
    }
}
