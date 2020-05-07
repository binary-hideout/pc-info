using PCInfoDesktop.Models;
using PCInfoDesktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        Employee GlobalEmployee { get; set; }

        public SystemInformationWindow(Employee employee)
        {
            InitializeComponent();
            this.DataContext = new SystemViewModel();
            GlobalEmployee = employee;
            Usuario.Content = GlobalEmployee.ID.ToString() + ", " + GlobalEmployee.Name + " " + GlobalEmployee.FirstLastName + " " + GlobalEmployee.SecondLastName;

        }

        private void GenerateReport(object sender, RoutedEventArgs e)
        {
            ReportGenerator.WriteReport(GlobalEmployee);
        }
    }
}
