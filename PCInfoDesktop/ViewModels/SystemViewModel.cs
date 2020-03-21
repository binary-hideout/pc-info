using PCInfoDesktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PCInfoDesktop.ViewModels
{
    public class SystemViewModel : BaseViewModel
    {

        private SysInfo _SystemInformation;
        public SysInfo SystemInformation
        {
            get => _SystemInformation;
            set
            {
                _SystemInformation = value;
                OnPropertyChanged();
            }
        }

        public SystemViewModel()
        {
            SystemInformation = new SysInfo();
        }

    }
}
