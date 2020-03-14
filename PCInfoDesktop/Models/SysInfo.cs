using System;
using System.Collections.Generic;
using System.Text;

namespace PCInfoDesktop.Models {
    /// <summary>
    /// Class to store system information: PC name, serial number and installed applications (software).
    /// </summary>
    public class SysInfo {
        /// <summary>
        /// PC name.
        /// </summary>
        public string PCName { get; private set; }

        /// <summary>
        /// Name of the operating system.
        /// </summary>
        public string OSName { get; private set; }

        /// <summary>
        /// ID of the operating system.
        /// </summary>
        public string OSId { get; private set; }

        /// <summary>
        /// Applications (software) that are installed in the PC.
        /// </summary>
        public List<InstalledApplication> InstalledApplications { get; private set; }
    }
}
