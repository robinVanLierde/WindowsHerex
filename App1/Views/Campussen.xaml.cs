using App1.Viewmodels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace App1.Views
{
    public sealed partial class Campussen : UserControl
    {
        public Campussen(MainViewModel mvm)
        {
            this.DataContext = new CampussenViewModel(mvm);
            ShowRouteOnMap2();
            this.InitializeComponent();
        }

        private async void ShowRouteOnMap2()
        {

            BasicGeoposition endLocation = new BasicGeoposition();
            // Request permission to access location
            var accessStatus = await Geolocator.RequestAccessAsync();

            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:


                    // If DesiredAccuracy or DesiredAccuracyInMeters are not set (or value is                       0), DesiredAccuracy.Default is used.
                    Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = 100 };

                    if (titel.ToString() == "Campus Mercator")
                    {
                        endLocation.Latitude = 51.042403;
                        endLocation.Longitude = 3.713265;
                    }
                    if (titel.ToString() == "Campus Schoonmeersen")
                    {
                        endLocation.Latitude = 51.031144;
                        endLocation.Longitude = 3.706399;
                    }
                    if (titel.ToString() == "Campus Schoonmeersen")
                    {
                        endLocation.Latitude = 50.937330;
                        endLocation.Longitude = 4.033362;
                    }

                    Geopoint point = new Geopoint(endLocation);

                    
                    MapIcon mapIcon = new MapIcon();
                    mapIcon.Location = point;
                    mapIcon.NormalizedAnchorPoint = new Point(0.5, 1.0);
                    mapIcon.Title = "Hier ligt de campus";
                    
                    MyMap.MapElements.Add(mapIcon);

                    break;

                case GeolocationAccessStatus.Denied:
                    //              
                    break;
            }


        }





    }
}
