using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace librus
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbpath)
        {
            _database = new SQLiteAsyncConnection(dbpath);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Score>().Wait();
            _database.CreateTableAsync<Subject>().Wait();
        }

        public Task<int> InsertUser(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<List<User>> GetAllUsers()
        {
            return _database.QueryAsync<User>("SELECT * FROM User");
        }

        public Task<List<User>> GetUserFilter(string login,string password)
        {
            return _database.QueryAsync<User>("SELECT * FROM User WHERE Login=? AND Password=?", login,password);
        }

        public Task<List<Subject>> GetSubjects()
        {
            return _database.QueryAsync<Subject>("SELECT * FROM subject");
        }

        public Task<List<Score>> GetScories()
        {
            return _database.QueryAsync<Score>("SELECT * FROM Score");
        }

        public Task<int> InsertSubject(Subject subject)
        {
            return _database.InsertAsync(subject);
        }

        public Task<int> InsertScore(Score score)
        {
            return _database.InsertAsync(score);
        }

        public Task<List<Score>> GetScories(int user_id, int subject_id, string period)
        {
            return _database.QueryAsync<Score>("SELECT * FROM Score WHERE User_id=? AND Subject_id=? AND Period=?", user_id, subject_id, period);
        }



    }
}
