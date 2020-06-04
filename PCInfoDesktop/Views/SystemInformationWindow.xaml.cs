using Microsoft.Win32;

using PCInfoDesktop.Models;
using PCInfoDesktop.ViewModels;

using System.Windows;

namespace PCInfoDesktop.Views {
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
            ReportGenerator.WriteReport(GlobalEmployee, false);
        }

        private void Browse_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(TxtCertPwd.Password)) {
                MessageBox.Show("Introduzca la contraseña del certificado antes de cargarlo.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var browsedFile = new OpenFileDialog() {
                Filter = "Personal Information Exchange (*.pfx)|*.pfx"
            };
            if (browsedFile.ShowDialog() == true) {
                ReportGenerator.WriteReport(GlobalEmployee, true);
                ElectronicSignature.SignPDF(GlobalEmployee.ID, browsedFile.FileName, TxtCertPwd.Password.ToCharArray());
            }
        }
    }
}
