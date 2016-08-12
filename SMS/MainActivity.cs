using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;

namespace SMS
{
    [Activity(Label = "SMS", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ViewAll);
            var db = new DatabaseManager();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.LoginBtn);
            EditText usernameTxt = FindViewById<EditText>(Resource.Id.UsernameTxt);
            EditText passwordTxt = FindViewById<EditText>(Resource.Id.PasswordTxt);
            TextView errorVw = FindViewById<TextView>(Resource.Id.ErrorVw);
            errorVw.SetTextColor(Color.Red);

            button.Click += (object sender, EventArgs e) => {
                if (db.Validate(usernameTxt.Text, passwordTxt.Text))
                {
                    Intent viewAll = new Intent(this, typeof(ViewAllActivity));
                    StartActivity(viewAll);
                }
                else
                {
                    errorVw.Text = "Invalid username or password.";
                }
            };

        }
    }
}

