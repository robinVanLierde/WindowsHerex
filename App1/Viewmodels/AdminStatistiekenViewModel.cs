using App1.Models;
using App1.Views;
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
using Newtonsoft.Json;

namespace App1.Viewmodels
{
    class AdminStatistiekenViewModel : INotifyPropertyChanged
    {
        MainViewModel mvm;

        public event PropertyChangedEventHandler PropertyChanged;

        public int aantGeregistreerd { get; set; }
        public int aantBedrijfsman { get; set; }
        public int aantOffice { get; set; }
        public int aantToegepaste { get; set; }
        public int aantRetail { get; set; }
        public ICommand navHome { get; set; }
        public ICommand refresh { get; set; }
        public ICommand navCrNewsfeed { get; set; }
        public ICommand downloadPdf { get; set; }

        private ObservableCollection<Leerling> leerlingen;

        public AdminStatistiekenViewModel(MainViewModel mvm)
        {
            this.mvm = mvm;
            
            Refresh(null);
            navHome = new RelayCommand(navHomepage, CanExecuteMethod);
            refresh = new RelayCommand(Refresh, CanExecuteMethod);
            downloadPdf = new RelayCommand(DownloadPdf, CanExecuteMethod);
            navCrNewsfeed = new RelayCommand(navCreateNewsfeed, CanExecuteMethod);
            aantGeregistreerd = 0;
            aantBedrijfsman = 0; //aantal geregistreerde studenten die bedrijfsmanagement kozen;
            aantOffice = 0; //aantal geregistreerde studenten die Office management kozen;
            aantToegepaste = 0; ; //aantal geregistreerde studenten die Toegepaste informatica kozen;
            aantRetail = 0; //aantal geregistreerde studenten die Retail management kozen;
        }
        public bool CanExecuteMethod(object obj)
        {
            return true;
        }

        public void navHomepage(object obj)
        {

            mvm.SelectedViewModel = new MainView(mvm);

        }
        public void navCreateNewsfeed(object obj)
        {

            mvm.SelectedViewModel = new CreateNewsfeed(mvm);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public async void Refresh(object obj)
        {
            aantGeregistreerd = 0;
            aantBedrijfsman = 0; //aantal geregistreerde studenten die bedrijfsmanagement kozen;
            aantOffice = 0; //aantal geregistreerde studenten die Office management kozen;
            aantToegepaste = 0; ; //aantal geregistreerde studenten die Toegepaste informatica kozen;
            aantRetail = 0; //aantal geregistreerde studenten die Retail management kozen;

            HttpClient client = new HttpClient();
            var jsonString = await client.GetStringAsync("http://localhost:6468/api/leerling");
            leerlingen = JsonConvert.DeserializeObject<ObservableCollection<Leerling>>(jsonString);

            
            aantGeregistreerd = leerlingen.Count();
            OnPropertyChanged("aantGeregistreerd");

            foreach (var item in leerlingen)
            {
                if (item.opleiding == "Bedrijfsmanagement")
                {
                    aantBedrijfsman += 1;
                    OnPropertyChanged("aantBedrijfsman");
                    
                }
                if (item.opleiding == "Retail Management")
                {
                    aantRetail = aantRetail + 1;
                    OnPropertyChanged("aantRetail");
                }
                if (item.opleiding == "Toegepaste Informatica")
                {
                    aantToegepaste += 1;
                    OnPropertyChanged("aantToegepaste");
                }
                if (item.opleiding == "Office Management")
                {
                    aantOffice += 1;
                    OnPropertyChanged("aantOffice");

                }
                
            }
            


            //als ge nog statistieken derbij wilt plaatsen maak nen public string aantRetail { get; set; } en vul em in kzal em dan wel toevoegen

        }
        public void DownloadPdf(object parameter)
        {
            //hier de code om alles op te vragen en te downloaden als pdf
          

        }

      
    }
}
