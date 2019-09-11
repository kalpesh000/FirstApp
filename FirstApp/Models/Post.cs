using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

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
    public class InsertClass
    {
        public int InsertExp(Post post)
        {
            int rows = 0;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                rows = conn.Insert(post);
            }

            return rows;
        }
    }
}
