using System;
using System.Collections.Generic;
using System.Text;

namespace PCInfoDesktop.Models {
    /// <summary>
    /// Data of an installed application (software) in the PC.
    /// </summary>
    public class InstalledApplication {
        /// <summary>
        /// Name of the application.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Publisher that installed the application.
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Date when the application was installed. It can be <c>null</c>, meaning that the date is unknown.
        /// </summary>
        public DateTime? InstallDate { get; set; }

        /// <summary>
        /// Estimated size in disk of the application.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Current version of the application.
        /// </summary>
        public string Version { get; set; }

    }
}
