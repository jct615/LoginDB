using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginDB
{
    public class User
    {
        public string _Username { get; set; }
        public string _Password { get; set; }

        public static int RegisterUser(string username, string password)
        {
            User data = new User
            {
                _Username = username,
                _Password = password,
            };
            string sql = @"INSERT INTO UsersTBL (Username, Passwords) values (@_Username, @_Password)";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static int LoginUser(string username, string password)
        {
            User data = new User 
            {
                _Username = username,
                _Password = password
            };
            string sql = @"SELECT Username, Passwords FROM UsersTBL WHERE Username=@_Username and Passwords=@_Password";
            return SqlDataAccess.SearchData(sql, data);
        }

        public static int CheckUser(string username)
        {
            User data = new User
            {
                _Username = username
            };
            string sql = @"SELECT Username from UsersTBL WHERE Username = @_Username";
            return SqlDataAccess.SearchData(sql, data);
        }

        public static int UpdateUser(string username, string password)
        {
            User data = new User 
            {
                _Username = username,
                _Password = password
            };
            string sql = @"UPDATE UsersTBL SET Username = @_Username and Passwords = @_Password";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static int DeleteUser(string username)
        {
            User data = new User
            {
                _Username = username
            };
            string sql = @"DELETE FROM UsersTBL WHERE Username = @_Username";
            return SqlDataAccess.SaveData(sql, data);
        }
    }
}