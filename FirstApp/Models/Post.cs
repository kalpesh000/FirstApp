using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Models
{
    public class Post
    {
        //Below are the SQLite attributes used to set ID as primary key and autoincrement.
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Experience { get; set; }

    }

    /// <summary>
    /// Declared a class for Insertion commands.
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
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(post);

                if (rows > 0)
                    return true;
                else
                    return false;
            }
        }

        public static bool Delete(Post post)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(post);

                if (rows > 0)
                    return true;
                else
                    return false;
            }
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


