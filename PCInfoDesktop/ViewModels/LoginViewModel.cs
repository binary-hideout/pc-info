using PCInfoDesktop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace PCInfoDesktop.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private Employee _employee;

        public Employee employee
        {
            get => _employee;
            set
            {
                _employee = value;
                OnPropertyChanged();
            }
        }

        private string _id;
        public string id
        {
            get { return this._id; }
            set
            {
                this._id = value;
                OnPropertyChanged();
            }
        }

        private string _userName;
        public string UserName
        {
            get { return this._userName; }
            set
            {
                this._userName = value;
                OnPropertyChanged();
            }
        }

        private string _userNameFirst;
        public string UserNameFirst
        {
            get { return this._userNameFirst; }
            set
            {
                this._userNameFirst = value;
                OnPropertyChanged();
            }
        }

        private string _userNameSecond;
        public string UserNameSecond
        {
            get { return this._userNameSecond; }
            set
            {
                this._userNameSecond = value;
                OnPropertyChanged();
            }
        }

        private ICommand _buttonCommand;
        public ICommand ButtonCommand
        {
            get { return this._buttonCommand; }
            set
            {
                this._buttonCommand = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel()
        {
            employee = new Employee(id, UserName, UserNameFirst, UserNameSecond);
            ButtonCommand = new RelayCommand(new Action<object>(ButtonClick));

        }

        public void ButtonClick(object obj)
        {
            Console.WriteLine("This works!");
        }

    }
}
