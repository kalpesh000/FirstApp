using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Models
{
    //Change the class defination to implement Interface fro Inotify Property
    public class Post : INotifyPropertyChanged
    {
        //Below are the SQLite attributes used to set ID as primary key and autoincrement.
        //[PrimaryKey, AutoIncrement]
        //public int Id { get; set; }

        private string id;
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                //Firing property changed event if there is change in property
                OnPropertyChanged("Id");
            }
        }

        //[MaxLength(250)]
        //public string Experience { get; set; }
        private string experience;
        public string Experience
        {
            get { return experience; }
            set
            {
                experience = value;
                //Firing property changed event if there is change in property
                OnPropertyChanged("Experience");
            }
        }

        //Evented added automatically for property changed
        public event PropertyChangedEventHandler PropertyChanged;

        //Created a method to fire the Inotify property changed event
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
    /// <summary>
    /// Declared a class for Database Access commands.
    /// </summary>
    public class DatabaseClass
    {
        public static bool Insert(Post post)
        {
            int rows = 0;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                rows = conn.Insert(post);
            }

            if (rows > 0)
                return true;
            else
                return false;
        }

        public static bool Update(Post post)
        {
            int rows = 0;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                rows = conn.Update(post);
            }

            if (rows > 0)
                return true;
            else
                return false;
        }

        public static bool Delete(Post post)
        {
            int rows = 0;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                rows = conn.Delete(post);

            }

            if (rows > 0)
                return true;
            else
                return false;
        }

        public static List<Post> HistoryView()
        {
            List<Post> posts;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                posts = conn.Table<Post>().ToList();
            }
            return posts;
        }
    }

    public class ProfileClass
    {
        public static string PostCount()
        {
            string postcount;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var postTable = conn.Table<Post>().ToList();

                postcount = postTable.Count.ToString();
            }
            return postcount;
        }
    }
}


