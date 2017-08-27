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
        MainViewModel mvm;

        public event PropertyChangedEventHandler PropertyChanged;
        public MainPageViewModel(MainViewModel Mvm)
        {
            this.mvm = Mvm;
            navPotStudent = new RelayCommand(navPotentStudent, CanExecuteMethod);
        }
        public bool CanExecuteMethod(object obj)
        {
            return true;
        }

        public void navPotentStudent(object obj)
        {

            mvm.SelectedViewModel = new PotentiëleStudenten(mvm);

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
