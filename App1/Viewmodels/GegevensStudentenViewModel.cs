using App1.Models;
using App1.Views;
using Newtonsoft.Json;
using ProjectWindows.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App1.Viewmodels
{
    class GegevensStudentenViewModel : INotifyPropertyChanged
    {
        MainViewModel mvm;
        private string _voornaam;
        public string Voornaam
        {
            get { return _voornaam; }
            set
            {
                
                _voornaam = value;
                OnPropertyChanged("Voornaam");

            }
        }
        public String Naam
        {
            get { return _naam; }
            set
            {
                if (value == _naam)
                    return;
                _naam = value;
                OnPropertyChanged("Naam");

            }
        }
        public String Adres
        {
            get { return _adres; }
            set
            {
                if (value == _adres)
                    return;
                _adres = value;
                OnPropertyChanged("Adres");

            }
        }
        public String Email
        {
            get { return _email; }
            set
            {
                if (value == _email)
                    return;
                _email = value;
                OnPropertyChanged("Email");

            }
        }
        public String Telefoon
        {
            get { return _telefoon; }
            set
            {
                if (value == _telefoon)
                    return;
                _telefoon = value;
                OnPropertyChanged("Telefoon");

            }
        }
        public String Opleiding
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
        public String Campus
        {
            get { return _campus; }
            set
            {
                if (value == _campus)
                    return;
                _campus = value;
                OnPropertyChanged("Campus");

            }
        }

        
        public String _naam;
        public String _adres;
        public String _email;
        public String _telefoon;
        public String _opleiding;
        public String _campus;



        private ObservableCollection<Leerling> _leerlingen;
        public ObservableCollection<Leerling> Leerlingen
        {
            get { return _leerlingen; }
            set
            {
                if (value == _leerlingen)
                    return;
                _leerlingen = value;
                OnPropertyChanged("Leerlingen");

            }
        }

        public ICommand navHome { get; set; }
        private Leerling _selectedLeerling;
        public Leerling SelectedLeerling
        {
            get { return _selectedLeerling; }
            set
            {
                if (value == _selectedLeerling)
                    return;
                _selectedLeerling = value;
                ChangeLeerling();
                OnPropertyChanged("SelectedLeerling");

            }
        }

        private void ChangeLeerling()
        {
            Voornaam = SelectedLeerling.Voornaam;
            Naam = SelectedLeerling.Naam;
            Adres = SelectedLeerling.Adres;
            Email = SelectedLeerling.Email;
            Telefoon = SelectedLeerling.Telefoon;
            Opleiding = SelectedLeerling.opleiding;
            Campus = SelectedLeerling.campus;
        }

        public GegevensStudentenViewModel(MainViewModel mvm)
        {
            this.mvm = mvm;
            getLeerlingen();
            
            navHome = new RelayCommand(navHomepage, CanExecuteMethod);
        }

        public async void getLeerlingen()
        {
            HttpClient client = new HttpClient();
            var jsonString = await client.GetStringAsync("http://localhost:6468/api/leerling");
            Leerlingen = JsonConvert.DeserializeObject<ObservableCollection<Leerling>>(jsonString);
            

        }
        public bool CanExecuteMethod(object obj)
        {
            return true;
        }

        public void navHomepage(object obj)
        {

            mvm.SelectedViewModel = new Adminstatistieken(mvm);

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
