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
    class AdminStatistiekenViewModel : INotifyPropertyChanged
    {
        MainViewModel mvm;

        public event PropertyChangedEventHandler PropertyChanged;

        public string aantGeregistreerd { get; set; }
        public string aantBedrijfsman { get; set; }
        public string aantOffice { get; set; }
        public string aantToegepaste { get; set; }
        public string aantRetail { get; set; }
        public ICommand navHome { get; set; }
        public ICommand refresh { get; set; }
        public ICommand navCrNewsfeed { get; set; }
        public ICommand downloadPdf { get; set; }

        public AdminStatistiekenViewModel(MainViewModel mvm)
        {
            this.mvm = mvm;
            Refresh(null);
            navHome = new RelayCommand(navHomepage, CanExecuteMethod);
            refresh = new RelayCommand(Refresh, CanExecuteMethod);
            downloadPdf = new RelayCommand(DownloadPdf, CanExecuteMethod);
            navCrNewsfeed = new RelayCommand(navCreateNewsfeed, CanExecuteMethod);
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

        public void Refresh(object obj)
        {
            //Hier moet de code om de statistieken op te vragen/
            aantGeregistreerd = "0";// totaal aantal geregistreerde studenten;
            aantBedrijfsman = "0"; //aantal geregistreerde studenten die bedrijfsmanagement kozen;
            aantOffice = "0"; //aantal geregistreerde studenten die Office management kozen;
            aantToegepaste = "0"; //aantal geregistreerde studenten die Toegepaste informatica kozen;
            aantRetail = "0"; //aantal geregistreerde studenten die Retail management kozen;



            //als ge nog statistieken derbij wilt plaatsen maak nen public string aantRetail { get; set; } en vul em in kzal em dan wel toevoegen

        }
        public void DownloadPdf(object obj)
        {
            //hier de code om alles op te vragen en te downloaden als pdf

        }
    }
}
