using PCInfoDesktop.Models;

namespace PCInfoDesktop.ViewModels {
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

            for (int i = 0; i < SystemInformation.InstalledApplications.Count; i++)
            {
                InstalledApps += SystemInformation.InstalledApplications[i].ToString() + "\n";
            }

        }

    }
}
