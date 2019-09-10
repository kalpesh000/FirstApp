using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirstApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //Defining source for Icon Image -E73 T7.31
            var assembly = typeof(MainPage);
            iconImage.Source = ImageSource.FromResource("FirstApp.Assets.Images.plane img.jpg", assembly);
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            //Get data on wheather user has filled the Email and Password textbox
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passswordEntry.Text);
            
            //Jump to the Homepage if user has entered Email and Password
            if(isEmailEmpty || isPasswordEmpty)
            {

            }
            else
            {
                //Jump to the Home Page
                Navigation.PushAsync(new HomePage());
            }

        }
    }
}
