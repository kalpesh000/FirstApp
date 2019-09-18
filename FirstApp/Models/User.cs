using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FirstApp.Models
{
    public class Users : INotifyPropertyChanged
    {
        private string id;
        public string Id
        {
            get { return id; }
            set {
                id = value;
                //Firing property changed event if there is change in property
                OnPropertyChanged("Id");
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set {
                email = value;
                //Firing property changed event if there is change in property
                OnPropertyChanged("Email");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                //Firing property changed event if there is change in property
                OnPropertyChanged("Password");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {            
            //Calling the PropertyChanged event before it is created or there are any 
            //subcribers will create exception because it sends notification to no one  
            //as their is no Event-handler like "OnPropertyChanged("Experience")" which
            //are subscribers to event.
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class UserClass
    {
        public static bool UserCheck(Users user)
        {
            //Get data on wheather user has filled the Email and Password textbox
            bool isEmailEmpty = string.IsNullOrEmpty(user.Email);
            bool isPasswordEmpty = string.IsNullOrEmpty(user.Password);

            //Jump to the Homepage if user has entered Email and Password
            if (isEmailEmpty || isPasswordEmpty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}