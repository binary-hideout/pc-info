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
            SystemInformationWindow systemInformationWindow = new SystemInformationWindow();
            systemInformationWindow.Show();
        }

    }
}
