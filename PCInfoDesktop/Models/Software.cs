using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCInfoDesktop.Models {
    /// <summary>
    /// Handles the installed software in the PC.
    /// </summary>
    public class Software {
        /// <summary>
        /// Gets the installed applications in the PC.
        /// </summary>
        public static void GetInstalledApps() {
            string registry = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (var key = Registry.LocalMachine.OpenSubKey(registry)) {
                foreach (var subKeyName in key.GetSubKeyNames()) {
                    using (var tempKey = key.OpenSubKey(subKeyName)) {
                        // list available values to get
                        //foreach (var name in tempKey.GetValueNames()) {
                        //    Console.WriteLine(name);
                        //}
                        var name = tempKey.GetValue("DisplayName");
                        var publisher = tempKey.GetValue("Publisher");
                        var date = tempKey.GetValue("InstallDate");
                        var size = tempKey.GetValue("EstimatedSize");
                        var version = tempKey.GetValue("DisplayVersion");
                        Console.WriteLine($"{name}, {publisher}, {date}, {size}, {version}");
                    }
                }
            }
        }
    }
}
