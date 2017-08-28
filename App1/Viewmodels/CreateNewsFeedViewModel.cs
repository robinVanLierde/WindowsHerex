using App1.Models;
using App1.Views;
using Newtonsoft.Json;
using ProjectWindows.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App1.Viewmodels
{
    class CreateNewsFeedViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand navHome { get; set; }
        public ICommand AddNewsfeed { get; set; }

        public DateTimeOffset Datum { get; set; }
        public string Opleiding { get; set; }
        public string Inhoud { get; set; }
        public string Titel { get; set; }
        public String vOpleiding { get; set; }
        public List<String> Opleidingen { get; set; }

        MainViewModel mvm;

        public CreateNewsFeedViewModel(MainViewModel mvm)
        {
            this.mvm = mvm;
            Opleidingen = new List<string>();
            Opleidingen.Add("Toegepaste Informatica");
            Opleidingen.Add(" Bedrijfsmanagement");
            Opleidingen.Add(" Office Management");
            Opleidingen.Add(" Retail Management");
            navHome = new RelayCommand(navHomepage, CanExecuteMethod);
            AddNewsfeed = new RelayCommand(CreateNewfeed, CanExecuteMethod);

        }
        public void navHomepage(object obj)
        {

            mvm.SelectedViewModel = new MainView(mvm);

        }
        public bool CanExecuteMethod(object obj)
        {
            return true;
        }
        public async void CreateNewfeed(object obj)
        {

            Newsfeed newNewsfeed = new Newsfeed()
            {
                Date = Datum,
                Inhoud = Inhoud,
                Opleiding = vOpleiding,
                Title = Titel
            };

            HttpClient client = new HttpClient();
            Uri theUri = new Uri("http://localhost:6468/api/newsfeeds");
            var jsonObject = JsonConvert.SerializeObject(newNewsfeed);
            StringContent content = new StringContent(jsonObject, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(theUri, content);

            if (response.IsSuccessStatusCode)
            {
                mvm.SelectedViewModel = new MainView(mvm);
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
