using App1.Viewmodels;
using ProjectWindows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
