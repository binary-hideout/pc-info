using Microsoft.Win32;

using System;
using System.Collections.Generic;

namespace PCInfoDesktop.Models {
    /// <summary>
    /// Handles the installed software in the PC.
    /// </summary>
    public static class Software {
        /// <summary>
        /// Registry key name to find 64-bit version of applications.
        /// </summary>
        private static string REGISTRY64 { get; } = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        /// <summary>
        /// Registry key name to find 32-bit version of applications.
        /// </summary>
        private static string REGISTRY32 { get; } = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";

        /// <summary>
        /// Gets the installed applications in the PC.
        /// </summary>
        public static void GetInstalledApps() {
            using (var key = Registry.LocalMachine.OpenSubKey(REGISTRY64)) {
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
