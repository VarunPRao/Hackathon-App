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
using Android;

namespace Hackathon_App
{

    [Activity(Label = "MenuActivity")]
    public class MenuActivity : Activity
    {

        private List<string> mList;
        private ListView mMenuList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Menu);
            mMenuList = FindViewById<ListView>(Resource.Id.MenuListView);

            mList = new List<string>();
            mList.Add("Analysis");
            mList.Add("Simulation");
            mList.Add("Order");
            mList.Add("Notification");

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1,mList);
            mMenuList.Adapter = adapter;

            mMenuList.ItemClick += mMenuList_ItemClick;
        }

        private void mMenuList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            switch(mList[e.Position])
            {
 
                case "Analysis":
                    StartActivity(typeof(Analysis));
                    break;
                case "Simulation":
                    StartActivity(typeof(Simulation));
                    break;
                case "Order":
                    StartActivity(typeof(Order));
                    break;
                case "Notification":
                    break;
            }
        }
    }
}