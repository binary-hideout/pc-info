using Microsoft.Win32;

using System;
using System.Linq;
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
        /// Registry key to get PC name.
        /// </summary>
        private static string REGISTRY_OS { get; } = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";

        /// <summary>
        /// Gets the installed applications by specified arguments.
        /// </summary>
        /// <param name="registryKey">Registry key object to search for.</param>
        /// <param name="registryName">Registry name to search for specified version of applications (32 or 64-bit).</param>
        /// <param name="currentList">List of <c>InstalledApplication</c> class. It can be empty but not <c>null</c>.</param>
        private  static List<InstalledApplication> GetInstalledAppsBy(RegistryKey registryKey, string registryName, List<InstalledApplication> currentList) {
            using (var subKey = registryKey.OpenSubKey(registryName)) {
                foreach (var subKeyName in subKey.GetSubKeyNames()) {
                    using (var tempKey = subKey.OpenSubKey(subKeyName)) {
                        // print available values to get
                        //foreach (var name in tempKey.GetValueNames()) {
                        //    Console.WriteLine(name);
                        //}
                        var name = tempKey.GetValue("DisplayName");
                        var publisher = tempKey.GetValue("Publisher");
                        var date = tempKey.GetValue("InstallDate");
                        var size = tempKey.GetValue("EstimatedSize");
                        var version = tempKey.GetValue("DisplayVersion");

                        var app = new InstalledApplication(name, publisher, date, size, version);

                        // if app's name is not empty and it hasn't been added
                        if (app.Name != string.Empty && !currentList.Any(listedApp => listedApp.Name == app.Name)) {
                            currentList.Add(app);
                        }
                    }
                }
            }

            return currentList;
        }

        /// <summary>
        /// Gets all the installed applications in the PC: for the current user and for all users (both 32 and 64-bits versions).
        /// </summary>
        /// <returns>List of installed apps sorted by name.</returns>
        public static List<InstalledApplication> GetAllInstalledApps() {
            // initialize list of installed apps as empty (not null).
            var installedApplications = new List<InstalledApplication>();

            // search apps in current user
            installedApplications = GetInstalledAppsBy(Registry.CurrentUser, REGISTRY64, installedApplications);
            // search apps in machine (all users)
            installedApplications = GetInstalledAppsBy(Registry.LocalMachine, REGISTRY64, installedApplications);
            // search apps in machine (32-bits version)
            installedApplications = GetInstalledAppsBy(Registry.LocalMachine, REGISTRY32, installedApplications);

            // sort apps by name
            installedApplications.Sort((app1, app2) => app1.Name.CompareTo(app2.Name));

            return installedApplications;
        }

        /// <summary>
        /// Gets a value of the operating system.
        /// </summary>
        /// <param name="machineName">Name of the local PC.</param>
        /// <param name="valueName">Name of the value or property to be retrieved.</param>
        /// <returns><c>string</c> containing the specified value.</returns>
        public static string GetOSValue(string machineName, string valueName) {
            using (var subKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, Environment.MachineName).OpenSubKey(REGISTRY_OS)) {
                return subKey.GetValue(valueName).ToString();
            }
        }
    }
}
