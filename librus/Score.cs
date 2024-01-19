using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace librus
{
    public class Score
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        
    }
}
