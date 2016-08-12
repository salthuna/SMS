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

namespace SMS
{
    [Table("Student")]
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Country{ get; set; }
    }
}