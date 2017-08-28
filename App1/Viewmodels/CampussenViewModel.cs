using App1.Views;
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
    class CampussenViewModel : INotifyPropertyChanged
    {
        MainViewModel mvm;
        public ICommand navHome { get; set; }
        private string _selectedCampus;
        public string SelectedCampus
        {
            get { return _selectedCampus; }
            set
            {
                if (value == _selectedCampus)
                    return;
                _selectedCampus = value;
                OnPropertyChanged("SelectedCampus");
                ChangeCampus();

            }
        }

        

        private string _titel;
        public string Titel
        {
            get { return _titel; }
            set
            {
                if (value == _titel)
                    return;
                _titel = value;
                OnPropertyChanged("Titel");

            }
        }
        private string _mainTekst;
        public string MainTekst
        {
            get { return _mainTekst; }
            set
            {
                if (value == _mainTekst)
                    return;
                _mainTekst = value;
                OnPropertyChanged("MainTekst");

            }
        }

        public List<String> Campussen { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public CampussenViewModel(MainViewModel mvm)
        {
            this.mvm = mvm;
            navHome = new RelayCommand(navHomepage, CanExecuteMethod);
            Campussen = new List<string>();
            Campussen.Add("Aalst");
            Campussen.Add("Schoonmeersen");
            Campussen.Add("Mercator");
        }

        public bool CanExecuteMethod(object obj)
        {
            return true;
        }
        public void navHomepage(object obj)
        {

            mvm.SelectedViewModel = new MainView(mvm);

        }

        private void ChangeCampus()
        {
            switch (SelectedCampus)
            {
                case "Schoonmeersen":
                    Titel = "Campus Schoonmeersen";
                    MainTekst = "V. Vaerwyckweg 1 (auto, post) \n\n Voskenslaan 270 \n\n 9000 Gent \n\n 09 243 20 04" ;
                    break;
                case "Mercator":
                    Titel = "Campus Mercator";
                    MainTekst = "Henleykaai 84 \n\n 9000 Gent \n\n 09 243 20 16";
                    break;
                case "Aalst":
                    Titel = "Campus Aalst";
                    MainTekst = "Arbeidstraat 14 \n\n 9300 Aalst \n\n09 243 38 00";
                    break;
            }
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
