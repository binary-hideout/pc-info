using PCInfoDesktop.Models;

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

        // Ya se que me vas a matar por esto pero Content="{Binding SystemInformation.InstalledAplications.ToString()}" No funciona
        private string _InstalledApps;
        public string InstalledApps
        {
            get => _InstalledApps;
            set
            {
                _InstalledApps = value;
                OnPropertyChanged();
            }
        }

        public SystemViewModel()
        {
            SystemInformation = new SysInfo();

            // El codigo mas asqueroso que vas a ver en tu vida
            for (int i = 0; i < SystemInformation.InstalledApplications.Count; i++)
            {
                InstalledApps += SystemInformation.InstalledApplications[i].ToString() + "\n";
            }
        }

    }
}
