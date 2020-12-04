using System;
using System.IO;

namespace Assessment.Helpers
{
    public static class Constants
    {
        //-----------Database Constants-----------------------
        public const string DatabaseFilename = "TodoSQLite.db3";
        public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache |
        // encrypt db for passwords protection
        SQLite.SQLiteOpenFlags.ProtectionComplete;
        // parameter constants
        public enum Parameter
        {
            ReminderListId
        }

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
        //----------------------------------------------
    }
}
