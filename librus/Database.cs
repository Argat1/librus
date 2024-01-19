using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace librus
{
    class Database
    {
        readonly SQLiteConnection _database;

        public Database(string dbpath)
        {
            _database = new SQLiteConnection(dbpath);
            _database.CreateTable<User>();
        }


    }
}
