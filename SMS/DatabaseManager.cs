using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;

namespace SMS
{
    public class DatabaseManager
    {
        private static string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "SMS_db1");
        private SQLiteConnection _db;

        public DatabaseManager()
        {
            _db = new SQLiteConnection(_dbPath);
            _db.CreateTable<User>();
            _db.CreateTable<Student>();

            if (_db.Table<User>().Count() == 0)
                CreateDatabase();
        }

        public void CreateDatabase()
        {

            // insert an admin user
            var user = new User() { Username="admin", Password = "123456"};
            _db.Insert(user);

            // insert some students
            var student = new Student() { FirstName = "Mohamed", LastName = "Alhi", Country = "Saudi Arabia", DOB = new DateTime(1993 , 1 , 1) };
            _db.Insert(student);
            student = new Student() { FirstName = "Jack", LastName = "Smith", Country = "Australia", DOB = new DateTime(1992, 2, 2) };
            _db.Insert(student);
            student = new Student() { FirstName = "John", LastName = "Smith", Country = "Australia", DOB = new DateTime(1993, 3, 3) };
            _db.Insert(student);
        }
        
        public bool Validate(string username, string password)
        {
            //check if user and password are valid.
            return _db.Table<User>().Where(x => x.Username == username && x.Password == password).Count() > 0;
        }

        public void AddStudent(string firstname, string lastname, string country, DateTime DOB)
        {
            var student = new Student() { FirstName = firstname, LastName = lastname, Country = country, DOB = DOB };
            _db.Insert(student);
        }

        public void UpdateStudent(Student s)
        {
            _db.Update(s, typeof(Student));
        }

        public Student GetStudent(int id)
        {
            return _db.Table<Student>().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Student> ReadAllStudents()
        {
            return _db.Table<Student>().ToList(); ;
        }
    }
}