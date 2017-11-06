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

namespace Hackathon_App
{
    [Activity(Label = "Analysis")]
    public class Analysis : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Analysis);

            TextView txtview = FindViewById<TextView>(Resource.Id.textView1);
            int x = INVtrack.function();
            string str = Convert.ToString(x);
            txtview.Text = (str);
        }
    }
}