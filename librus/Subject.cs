using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace librus
{
    public class Subject
    {
        [PrimaryKey, AutoIncrement]
        public int Subject_id { get; set; }
        public string Subject_name { get; set; }
    }
}
