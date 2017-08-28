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
    class NewsFeedViewModel : INotifyPropertyChanged
    {
        MainViewModel mvm;
        private string _selectedOpleiding;
        public List<String> Opleidingen { get; set; }
        public string SelectedOpleiding
        {
            get { return _selectedOpleiding; }
            set
            {
                if (value == _selectedOpleiding)
                    return;
                _selectedOpleiding = value;
                OnPropertyChanged("SelectedOpleiding");
                FilterOpleiding();

            }
        }

        private void FilterOpleiding()
        {
            switch (SelectedOpleiding)
            {
                case "Bedrijfsmanagement":
                    
                    break;
                case "Office management":
                    break;
                case "Toegepaste Informatica":
                    break;
                case "Retail management":
                   break;
                case "Algemeen":
                    break;

            }
            //ier de filter op opleiding
        }

        private ObservableCollection<Newsfeed> _newsFeeds;
        public ObservableCollection<Newsfeed> Newsfeeds
        {
            get { return _newsFeeds; }
            set
            {
                if (value == _newsFeeds)
                    return;
                _newsFeeds = value;
                OnPropertyChanged("Newsfeeds");

            }
        }

        public ICommand navHome { get; set; }
        private Newsfeed _selectedNewsFeed;
        public Newsfeed SelectedNewsFeed
        {
            get { return _selectedNewsFeed; }
            set
            {
                if (value == _selectedNewsFeed)
                    return;
                _selectedNewsFeed = value;
                OnPropertyChanged("SelectedNewsFeed");
                ChangeNewsFeed();

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
        public NewsFeedViewModel(MainViewModel mvm)
        {
            Newsfeeds = new ObservableCollection<Newsfeed>();
            Opleidingen = new List<string>();
            Opleidingen.Add("Toegepaste Informatica");
            Opleidingen.Add("Bedrijfsmanagement");
            Opleidingen.Add("Office management");
            Opleidingen.Add("Retail management");
            Opleidingen.Add("Algemeen");
            getNewsFeeds();
            this.mvm = mvm;
            navHome = new RelayCommand(navHomepage, CanExecuteMethod);
        }
        public async void getNewsFeeds()
        {
            HttpClient client = new HttpClient();
            var jsonString = await client.GetStringAsync("http://localhost:6468/api/newsfeeds");
            ObservableCollection<Newsfeed> tijdelijk = new ObservableCollection<Newsfeed>();
            
            tijdelijk = JsonConvert.DeserializeObject<ObservableCollection<Newsfeed>>(jsonString);
            foreach (var item in tijdelijk)
            {
                if (item.Type == "Newsfeed")
                {
                    Newsfeeds.Add(item);
                }
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
        private void ChangeNewsFeed()
        {
            Titel = SelectedNewsFeed.Title;
            Datum = SelectedNewsFeed.Date.Date.ToString();
            Opleiding = SelectedNewsFeed.Opleiding;
            MainTekst = SelectedNewsFeed.Inhoud;
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
