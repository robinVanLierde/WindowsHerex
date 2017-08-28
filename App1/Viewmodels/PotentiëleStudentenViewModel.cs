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
    class PotentiëleStudentenViewModel : INotifyPropertyChanged
    {
        public ICommand navHome { get; set; }
        public ICommand AddLeerling { get; set; }
        
        public string Voornaam { get; set; }
        public String Naam { get; set; }
        public String Adres { get; set; }
        public String Email { get; set; }
        public String Telefoon { get; set; }
        public String vOpleiding { get; set; }
        public String vCampus { get; set; }
        public List<String> Opleidingen { get; set; }
        public List<String> Campussen { get; set; }
        MainViewModel mvm;

        public event PropertyChangedEventHandler PropertyChanged;

        public PotentiëleStudentenViewModel(MainViewModel mvm)
        {
            this.mvm = mvm;
            Opleidingen = new List<string>();
            Campussen = new List<string>();
            Opleidingen.Add("Toegepaste Informatica");
            Opleidingen.Add("Bedrijfsmanagement");
            Opleidingen.Add("Office management");
            Opleidingen.Add("Retail management");
            Campussen.Add("Schoonmeersen");
            Campussen.Add("Mercator");
            navHome = new RelayCommand(navHomepage, CanExecuteMethod);
            AddLeerling = new RelayCommand(CreateLln, CanExecuteMethod);
        }
        public bool CanExecuteMethod(object obj)
        {
            return true;
        }

        public void navHomepage(object obj)
        {

            mvm.SelectedViewModel = new MainView(mvm);

        }
        public void CreateLln(object obj)
        {

            Leerling nieuweLeerling = new Leerling();
            nieuweLeerling.Voornaam = Voornaam;
            nieuweLeerling.Naam = Naam;
            nieuweLeerling.Adres = Adres;
            nieuweLeerling.Email = Email;
            nieuweLeerling.Telefoon = Telefoon;
            nieuweLeerling.opleiding = vOpleiding;
            nieuweLeerling.campus = vCampus;
            // hier moet je dan de nieuwe leerling registreren in de backend





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
