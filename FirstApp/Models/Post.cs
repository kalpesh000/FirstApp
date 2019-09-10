using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp.Models
{
    public class Post
    {
        //Below are the SQLite attributes used to set ID as primary key and aur=toincrement.
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Experience { get; set; }
    }
}
