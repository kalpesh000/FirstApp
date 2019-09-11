using FirstApp.Models;
using SQLite;
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
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
        }

        private void SaveExp_Clicked(object sender, EventArgs e)
        {
            //Defining the next Experience entry inside the Post class.
            Post post = new Post()
            {
                Experience = experienceEntry.Text
            };

            //New class fro inserting experience to database
            InsertClass insertC =new InsertClass();

            //Inserting Experiences to database
            int rows = insertC.InsertExp(post);

            //Checking wheater the Experince is insereted or not.
            if (rows > 0)
                DisplayAlert("Success", "Experience sucessfully inserted!!!", "Ok");
            else
                DisplayAlert("Success", "Experience failed to be inserted!!!", "Ok");
        }
    }
}