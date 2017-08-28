using App1.Views;
using ProjectWindows.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App1.Viewmodels
{
    class AdminViewModel
    {
        MainViewModel mvm;
        public ICommand navHome { get; set; }
        public ICommand login { get; set; }
        public String loginNaam { get; set; }
        public String paswoord { get; set; }
        public AdminViewModel(MainViewModel mvm)
        {
            this.mvm = mvm;
            navHome = new RelayCommand(navHomepage, CanExecuteMethod);
            login = new RelayCommand(Login, CanExecuteMethod);
        }

        private void Login(object obj)
        {

            if (loginNaam == "administrator" && paswoord == "123")
            {
                mvm.SelectedViewModel = new MainView(mvm);
            }
        }

        public bool CanExecuteMethod(object obj)
        {
            return true;
        }
        public void navHomepage(object obj)
        {

            mvm.SelectedViewModel = new MainView(mvm);

        }
    }
}
