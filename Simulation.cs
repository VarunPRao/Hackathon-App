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

namespace Hackathon_App
{
    [Activity(Label = "Simulation")]
    public class Simulation : Activity
    {
        public class OrdData
        {
            private int Scanned { get; set; }
            public OrdData(int sca)
            {
                Scanned = sca;
            }

        }

        DateTime CurrentDate;
        int txtScannedInt;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Simulation);

            Button ScanButton = FindViewById<Button>(Resource.Id.btnSimSave);
            ScanButton.Click += ScanButton_Click;
        }


        private void ScanButton_Click(object sender, EventArgs e)
        {
            EditText txtScanned = FindViewById<EditText>(Resource.Id.txtSimScan);
            EditText txtDate = FindViewById<EditText>(Resource.Id.txtSimDate);

            txtScannedInt = Int32.Parse(txtScanned.Text);
            CurrentDate = DateTime.Parse(txtDate.Text);

            INVtrack.TakefromInv(txtScannedInt, CurrentDate);

            Finish();
        }
    }
    
}