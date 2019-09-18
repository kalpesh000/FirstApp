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
    public partial class PostDetailPage : ContentPage
    {
        Post selectedPost;
        public PostDetailPage(Post selectedPost)
        {
            InitializeComponent();

            this.selectedPost = selectedPost;

            //Binded the Experience stacklayout with the Database Post table for 
            //using Inotify Property -E99
            updateStackLayout.BindingContext = selectedPost;

            //Fill the experienceUpdateEntry with existing experience
            experienceUpdateEntry.Text = selectedPost.Experience;
        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            //Removed the definiation for creating new post and linking the   
            //recieved text with database for using Inotify Property -E99
            /*
            selectedPost.Experience = experienceUpdateEntry.Text;
            */
            bool isUpdated = DatabaseClass.Update(selectedPost);

            if (isUpdated)
                DisplayAlert("Success", "Experience sucessfully updated.", "Ok");
            else
                DisplayAlert("Success", "Experience failed to be updated.", "Ok");
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            bool isDeleted = DatabaseClass.Delete(selectedPost);
            if (isDeleted)
                DisplayAlert("Success", "Experience sucessfully deleted.", "Ok");
            else
                DisplayAlert("Success", "Experience failed to be deleted", "Ok");
        }
    }
}