using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PCInfoDesktop.ViewModels {
    /// <summary>
    /// Base view-model that the rest of view-models will inherit.
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged {

        protected BaseViewModel() { }

        /// <summary>
        /// Event raised when a property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method to apply to every property of a child view-model, e.g. 
        /// <code>public var SomeProperty {get => _someProperty; set { _someProperty = value; OnPropertyChanged() }</code>
        /// </summary>
        /// <param name="propertyName">The property's name. It is unnecessary to specify as the name is automatically used.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName)
            );
        }
    }
}