using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace SMS
{
    [Activity(Label = "SMS")]
    public class UpdateActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Update);

            var db = new DatabaseManager();
            Button btn = FindViewById<Button>(Resource.Id.UpdateBtn);
            EditText studentIdTxt = FindViewById<EditText>(Resource.Id.StudentIdTxt);
            EditText firstnameTxt = FindViewById<EditText>(Resource.Id.FirstNameTxt);
            EditText lastnameTxt = FindViewById<EditText>(Resource.Id.LastNameTxt);
            EditText dobTxt= FindViewById<EditText>(Resource.Id.DOBTxt);
            EditText countryTxt = FindViewById<EditText>(Resource.Id.CountryTxt);

            if (Intent.GetStringExtra("action") == "add")
            {
                btn.Text = "Add";
            }
            else
            {                
                //load data
                var student = db.GetStudent(Intent.GetIntExtra("id", 0));
                studentIdTxt.Text = student.Id.ToString();
                firstnameTxt.Text = student.FirstName;
                lastnameTxt.Text = student.LastName;
                dobTxt.Text = student.DOB.ToString("dd/MM/yyyy");
                countryTxt.Text = student.Country;
            }

            btn.Click += (object sender, EventArgs e) =>
            {
                if (Intent.GetStringExtra("action") == "add")
                {
                    btn.Text = "Add";
                    db.AddStudent(firstnameTxt.Text, lastnameTxt.Text, countryTxt.Text, DateTime.Parse(dobTxt.Text));
                }
                else
                {
                    Student s = new Student
                    {
                        Id = Int32.Parse(studentIdTxt.Text),
                        FirstName = firstnameTxt.Text,
                        LastName = lastnameTxt.Text,
                        DOB = DateTime.Parse(dobTxt.Text),
                        Country = countryTxt.Text
                    };

                    db.UpdateStudent(s);
                }

                Intent viewAll = new Intent(this, typeof(ViewAllActivity));
                StartActivity(viewAll);
            };

        }
    }
}

