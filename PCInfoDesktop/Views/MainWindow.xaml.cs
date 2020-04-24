using PCInfoDesktop.Models;
using System;
using System.Windows;

namespace PCInfoDesktop.Views {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void SwitchWindows(object sender, RoutedEventArgs e)
        {
            string UserID = textBoxID.Text;
            string UserName = textBoxUser.Text;
            string UserNameFirst = textBoxFirst.Text;
            string UserNameSecond = textBoxLast.Text;
            Employee employee = new Employee(UserID, UserName, UserNameFirst, UserNameSecond);
            SystemInformationWindow systemInformationWindow = new SystemInformationWindow(employee);
            systemInformationWindow.Show();
        }

    }
}
