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

        bool hasBeenClicked = false;

        private void textBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int ID = Int32.Parse(textBoxID.Text);
            string Name = textBoxUser.Text;
            string firstLast = textBoxFirst.Text;
            string secondLast = textBoxLast.Text;

            Employee employee = new Employee(ID, Name, firstLast, secondLast);

            SystemInformationWindow systemInformationWindow = new SystemInformationWindow(employee);
            systemInformationWindow.Show();
        }
    }
}
