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
        public string Name { get; private set; }

        /// <summary>
        /// PC serial number.
        /// </summary>
        public string SerialNumber { get; private set; }

        /// <summary>
        /// Applications (software) that are installed in the PC.
        /// </summary>
        public List<InstalledApplication> InstalledApplications { get; private set; }
    }
}
