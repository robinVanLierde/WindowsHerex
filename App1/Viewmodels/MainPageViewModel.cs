
﻿using App1.Views;

﻿using ProjectWindows;

using ProjectWindows.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App1.Viewmodels
{
    class MainPageViewModel : INotifyPropertyChanged
    {

        public ICommand navPotStudent { get; set; }
        public ICommand navCrNewsfeed { get; set; }

        public ICommand navOpleidingen{ get; set; }

        MainViewModel mvm;

        public event PropertyChangedEventHandler PropertyChanged;
        public MainPageViewModel(MainViewModel Mvm)
        {

            this.mvm = Mvm;
            navCrNewsfeed = new RelayCommand(navCreateNewsfeed, CanExecuteMethod);
            navPotStudent = new RelayCommand(NavPotentStudent, CanExecuteMethod);
            navOpleidingen = new RelayCommand(NavOpleidingen, CanExecuteMethod);

        }
        
        public bool CanExecuteMethod(object obj)
        {
            return true;
        }

        public void NavPotentStudent(object obj)
        {

            mvm.SelectedViewModel = new PotentiëleStudenten(mvm);

        }

        public void navCreateNewsfeed(object obj)
        {

            mvm.SelectedViewModel = new CreateNewsfeed(mvm);
        }
        public void NavOpleidingen(object obj)
        {

            mvm.SelectedViewModel = new Opleidingen(mvm);


        }
        private void OnPropertyChanged(string propName)

        {

            if (PropertyChanged != null)

            {

                PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }

        }
    }
}
