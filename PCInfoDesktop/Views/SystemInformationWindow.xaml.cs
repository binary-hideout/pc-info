using PCInfoDesktop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PCInfoDesktop.Views
{
    /// <summary>
    /// Interaction logic for SystemInformationWindow.xaml
    /// </summary>
    public partial class SystemInformationWindow : Window
    {
        public SystemInformationWindow(Employee employee)
        {
            InitializeComponent();
            Usuario.Content = "Bienvenido: " + employee.ID.ToString() + " " + employee.Name + " " + employee.FirstLastName + " " + employee.SecondLastName;
            SysInfo systemInformation = new SysInfo();
            sysName.Content = "Nombre del equipo: " + systemInformation.PCName;
            sysOS.Content = "Sistema operativo: " + systemInformation.OSName;
            InstalledApps.Content = systemInformation.InstalledApplications[8].Size;
        }
    }
}
