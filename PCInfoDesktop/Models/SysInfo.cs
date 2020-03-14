using System;
using System.Collections.Generic;
using System.Text;

namespace PCInfoDesktop.Models {
    /// <summary>
    /// Class to store system information.
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

        /// <summary>
        /// Constructs an object containing basic system information: PC name, OS name, OS ID and installed applications.
        /// </summary>
        public SysInfo() {
            PCName = Environment.MachineName;
            OSName = Software.GetOSValue(PCName, "ProductName");
            OSId = Software.GetOSValue(PCName, "ProductId");
            InstalledApplications = Software.GetAllInstalledApps();
        }
    }
}
