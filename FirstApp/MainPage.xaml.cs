using FirstApp.Models;
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
        Users user;
        public MainPage()
        {
            InitializeComponent();

            //Binded the Experience stacklayout with the User table for 
            //using Inotify Property -E99
            user = new Users();
            loginStackLayout.BindingContext = user;

            //Defining source for Icon Image -E73 T7.31
            var assembly = typeof(MainPage);
            iconImage.Source = ImageSource.FromResource("FirstApp.Assets.Images.plane img.jpg", assembly);
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            //Removed the definiation for creating new post and linking the   
            //recieved text with database for using Inotify Property -E99
            /*
            //Defining the next Experience entry inside the Post class.
            Users user = new Users()
            {
                Email = emailEntry.Text,
                Password = passswordEntry.Text
            };
            */

            //Get data on wheather user has filled the Email and Password textbox
            bool isUserCheck = UserClass.UserCheck(user);
            
            //Jump to the Homepage if user has entered Email and Password
            if(isUserCheck)
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
