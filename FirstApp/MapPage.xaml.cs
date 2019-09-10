using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private bool hasLocationPermission = false;
        public MapPage()
        {
            InitializeComponent();

            GetPermissions();

            //GetLocation();
        }

        private async void GetPermissions()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);

                if (status != PermissionStatus.Granted)
                {
                    //Wheater or not we should request a permission -E62 T14:05
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                    {
                        await DisplayAlert("Need your Location!", "We need to access your location.", "Ok");
                    }

                    //For requesting permission give alert and get the result of users selection -E62 T12:42
                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
                    if (results.ContainsKey(Permission.LocationWhenInUse))
                        status = results[Permission.LocationWhenInUse];
                }
                if (status == PermissionStatus.Granted)
                {
                    hasLocationPermission = true;
                    locationMap.IsShowingUser = true;

                    GetLocation();
                }
                else
                {
                    await DisplayAlert("Location Denied!", "Permission was not granted so we can't show Map.", "Ok");
                }
            }

            catch(Exception ex)
            {
               await DisplayAlert("Error",ex.Message,"Ok");
            }
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //Check if permission is granted for accessing the location. -E63
            if (hasLocationPermission)
            {
                //Get current position -E63
                var locator = CrossGeolocator.Current;
                
                //Subcribe to the event to get the postion changes -E63 T9.00
                locator.PositionChanged += Locator_PositionChanged;

                //Start listening to loaction changes.-E63 T12.00
                //As by default if listening is activated then this will drain the battery. 
                await locator.StartListeningAsync(TimeSpan.Zero,100);
            }
                GetLocation();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            //Stop listening to location changes. -E63 T14.00
            CrossGeolocator.Current.StopListeningAsync();
            //Unsubscribe to the event so one doesn't have many event handlers to be executed. -E63 T14.50
            CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged;
        }

        //Position change event handler -E63 T 9.00
        private void Locator_PositionChanged(object sender, PositionEventArgs e)
        {
            MoveMap(e.Position);
            //throw new NotImplementedException();
        }

        private async void GetLocation()
        {
            //Check if permission is granted for accessing the location. -E63
            if (hasLocationPermission)
            {
                //Get current position -E63
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();

                MoveMap(position);
            }
        }

        private void MoveMap(Position position)
        {
            //Move map to location -E63
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);
            locationMap.MoveToRegion(span);
        }
    
    }
}