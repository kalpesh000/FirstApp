﻿using FirstApp.Models;
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
        Post post;
        public AddPage()
        {
            InitializeComponent();

            //Binded the Experience stacklayout with the Database Post table for 
            //using Inotify Property -E99
            post = new Post();
            experienceStackLayout.BindingContext = post;
        }

        private void SaveExp_Clicked(object sender, EventArgs e)
        {
            //Removed the definiation for creating new post and linking the   
            //recieved text with database for using Inotify Property -E99
            /*
            //Defining the next Experience entry inside the Post class.
            Post post = new Post()
            {
                Experience = experienceEntry.Text
            };
            */

            //Inserting Experiences to database
            bool databaseEntry = DatabaseClass.Insert(post);

            //Checking wheater the Experince is insereted or not.
            if (databaseEntry)
                DisplayAlert("Success", "Experience sucessfully inserted!!!", "Ok");
            else
                DisplayAlert("Success", "Experience failed to be inserted!!!", "Ok");
        }
    }
}