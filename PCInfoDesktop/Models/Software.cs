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
            string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (var key = Registry.LocalMachine.OpenSubKey(registryKey)) {
                foreach (var subkeyName in key.GetSubKeyNames()) {
                    using (var subkey = key.OpenSubKey(subkeyName)) {
                        var appName = subkey.GetValue("DisplayName");
                        Console.WriteLine(appName);
                    }
                }
            }
        }

    }
}
