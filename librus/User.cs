using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace librus
{
    public class User
    {
        [PrimaryKey,AutoIncrement]
        public int User_id { get; set; }
        public int Name { get; set; }
        public string Username{ get; set; }
        public string Password { get; set; }
        public string Login {  get; set; }
        public bool IsTeacher { get; set; }
    }
}
