using PCInfoDesktop.Models;
using PCInfoDesktop.ViewModels;
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
        public SystemInformationWindow()
        {
            InitializeComponent();
            this.DataContext = new SystemViewModel();

        }

    }
}
