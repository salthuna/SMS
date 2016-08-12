using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Java.Util;

namespace SMS
{
    [Activity(Label = "SMS")]
    public class ViewAllActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ViewAll);
            var db = new DatabaseManager();
            var students = db.ReadAllStudents();
            Button btn = FindViewById<Button>(Resource.Id.AddBtn);
            ListView list = FindViewById<ListView>(Resource.Id.StudentLstVw);

            var names = new List<string>() ;
            foreach (var s in students)
                names.Add(s.FirstName + " " + s.LastName);
            list.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, names);

            list.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) =>
            {
                Intent update = new Intent(this, typeof(UpdateActivity));
                update.PutExtra("action", "update");
                update.PutExtra("id", students[e.Position].Id);
                StartActivity(update);
            };

            btn.Click += (object sender, EventArgs e) =>
            {
                Intent update = new Intent(this, typeof(UpdateActivity));
                update.PutExtra("action", "add");
                StartActivity(update);
            };
        }
    }
}

