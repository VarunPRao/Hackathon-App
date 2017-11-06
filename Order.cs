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
using System.IO;
using Android;

namespace Hackathon_App
{
    [Activity(Label = "Order")]
    public class Order : Activity
    {

        public class OrdData
        {
            private int Quantity { get; set; }
            public OrdData(int qty)
            {
                Quantity = qty;
            }

        }

        int txtQuantityInt;
        DateTime CurrentDate;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Order);

            Button OrderButton = FindViewById<Button>(Resource.Id.OrderButton);
            OrderButton.Click += OrderButton_Click;
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            EditText txtQuantity = FindViewById<EditText>(Resource.Id.QuantityofOrder);
            EditText txtDate = FindViewById<EditText>(Resource.Id.DateofOrder);

            CurrentDate = DateTime.Parse(txtDate.Text);
            txtQuantityInt = Int32.Parse(txtQuantity.Text);

            INVtrack.AddtoInv(txtQuantityInt,CurrentDate);

            Finish();
        }
    }
}
