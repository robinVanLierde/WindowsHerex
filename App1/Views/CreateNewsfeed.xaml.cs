using App1.Viewmodels;
using ProjectWindows;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateNewsfeed : Page
    {
        public CreateNewsfeed(MainViewModel mvm)
        {
            this.DataContext = new CreateNewsFeedViewModel(mvm);
            this.InitializeComponent();
            
        }

        private void Navigate_Mainpage(object sender, RoutedEventArgs e)
        {


            this.Frame.Navigate(typeof(MainPage), null);
        }

        private void AddNewsfeed(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), null);
        }
    }
}
