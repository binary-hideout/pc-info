using System;
using System.Globalization;

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
        /// Date when the application was installed. It can be <c>default</c> (<c>DateTime.MinValue</c>), meaning that the date is unknown.
        /// </summary>
        public DateTime InstallDate { get; set; }

        /// <summary>
        /// Estimated size in disk of the application.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Current version of the application.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Constructs an installed application by raw input (of type <c>object</c>) from <c>Software</c> class' method. If an argument is <c>null</c>, the corresponding property will be set as an empty string, or <c>default</c> in the case of the date.
        /// </summary>
        /// <param name="name">Name of the application.</param>
        /// <param name="publisher">Publisher that installed the app.</param>
        /// <param name="installDate">Date when the app was installed in format <c>yyyyMMdd</c>.</param>
        /// <param name="size">Size in disk of the app.</param>
        /// <param name="version">Version of the app.</param>
        /// <seealso cref="Software"/>
        public InstalledApplication(object name, object publisher, object installDate, object size, object version) {
            Name = name is null ? string.Empty : name.ToString();
            Publisher = publisher is null ? string.Empty : publisher.ToString();
            InstallDate = installDate is null ? default : ParseRawDate(installDate.ToString());
            Size = size is null ? 0 : Convert.ToInt32(size);
            Version = version is null ? string.Empty : version.ToString();
        }

        /// <summary>
        /// Parses raw date format <c>yyyyMMdd</c> to a valid <c>DateTime</c> object.
        /// </summary>
        /// <param name="rawFormat"><c>string</c> representing a date in format <c>yyyyMMdd</c>.</param>
        /// <returns><c>DateTime</c> if the <c>rawFormat</c> is not empty, else <c>default</c>.</returns>
        private DateTime ParseRawDate(string rawFormat) {
            try {
                var date = DateTime.ParseExact(rawFormat, "yyyyMMdd", CultureInfo.InvariantCulture);
                return date;
            }
            // if the string argument is empty, an exception will be raised and the method will return DateTime.MinValue
            catch (FormatException) {
                return default;
            }
        }

        /// <summary>
        /// Creates a <c>string[5]</c> collection of the instance's properties in the following order: name, publisher, date, size, version.
        /// </summary>
        /// <returns><c>string[5]</c> of the properties.</returns>
        public string[] ToArray() {
            string date = InstallDate == default ? string.Empty : InstallDate.ToShortDateString();
            string size = Size == 0 ? string.Empty : Size.ToString();
            return new string[] { Name, Publisher, date, size, Version };
        }

        /// <summary>
        /// Makes a <c>string</c> representation of the installed application.
        /// </summary>
        /// <returns><c>string</c> representing the application.</returns>
        public override string ToString() {
            return string.Join(" ", ToArray());
        }
    }
}
