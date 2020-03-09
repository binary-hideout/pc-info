using System;
using System.Collections.Generic;
using System.Globalization;
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

        /// <summary>
        /// Constructs an installed application by raw input from <c>Software</c> class' method.
        /// </summary>
        /// <param name="name">Name of the application.</param>
        /// <param name="publisher">Publisher that installed the app.</param>
        /// <param name="installDate">Date when the app was installed in format <c>yyyyMMdd</c>.</param>
        /// <param name="size"><c>string</c> representing the size in disk of the app.</param>
        /// <param name="version">Version of the app.</param>
        /// <seealso cref="Software"/>
        public InstalledApplication(string name, string publisher, string installDate, string size, string version) {
            Name = name;
            Publisher = publisher;
            InstallDate = ParseRawDate(installDate);
            Size = Convert.ToInt32(size);
            Version = version;
        }

        /// <summary>
        /// Parses raw date format <c>yyyyMMdd</c> to a valid <c>DateTime</c> object.
        /// </summary>
        /// <param name="rawFormat"><c>string</c> representing a date in format <c>yyyyMMdd</c>.</param>
        /// <returns><c>DateTime</c> if the <c>rawFormat</c> is not empty, else <c>null</c>.</returns>
        private DateTime? ParseRawDate(string rawFormat) {
            try {
                var date = DateTime.ParseExact(rawFormat, "yyyyMMdd", CultureInfo.InvariantCulture);
                return date;
            }
            // if the string argument is empty, an exception will be raised and the method will return null
            catch (FormatException) {
                return null;
            }

        }
    }
}
