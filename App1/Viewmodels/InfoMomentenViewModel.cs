
using App1.Models;
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
    class InfoMomentenViewModel : INotifyPropertyChanged
    {
        MainViewModel mvm;
        public List<Newsfeed> infoMomenten { get; set; }
        public ICommand navHome { get; set; }
        private Newsfeed _selectedInfoMoment;
        public Newsfeed SelectedInfoMoment
        {
            get { return _selectedInfoMoment; }
            set
            {
                if (value == _selectedInfoMoment)
                    return;
                _selectedInfoMoment = value;
                OnPropertyChanged("SelectedInfoMoment");
                ChangeInfoMoment();

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
        private string _datum;
        public string Datum
        {
            get { return _datum; }
            set
            {
                if (value == _datum)
                    return;
                _datum = value;
                OnPropertyChanged("Datum");

            }
        }
        private string _opleiding;
        public string Opleiding
        {
            get { return _opleiding; }
            set
            {
                if (value == _opleiding)
                    return;
                _opleiding = value;
                OnPropertyChanged("Opleiding");

            }
        }
        public InfoMomentenViewModel(MainViewModel mvm)
    {
            
            infoMomenten = new List<Newsfeed>();// hier moeten dan alle infomomenten ingestoken worden, dan zou et af moeten zijn
            navHome = new RelayCommand(navHomepage, CanExecuteMethod);
            this.mvm = mvm;
    }
        public bool CanExecuteMethod(object obj)
        {
            return true;
        }

        public void navHomepage(object obj)
        {

            mvm.SelectedViewModel = new MainView(mvm);

        }
        private void ChangeInfoMoment()
        {
            Titel = SelectedInfoMoment.Title;
            Datum = SelectedInfoMoment.Date.Date.ToString();
            Opleiding = SelectedInfoMoment.Opleiding;
            MainTekst = SelectedInfoMoment.Inhoud;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)

        {

            if (PropertyChanged != null)

            {

                PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }

        }
    }
}
