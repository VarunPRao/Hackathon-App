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
    class SignInDialog : DialogFragment 
    {

        EditText mtxtEmail;
        EditText mtxtPassword;

        public event EventHandler<OnSignInEventArgs> mOnSignInEvent;

        public class OnSignInEventArgs : EventArgs
        {
            private string mEmail;
            private string mPassword;
            public string Email
            {
                get { return mEmail; }
                set { mEmail = value; }
            }
            public string Password
            {
                get { return mPassword; }
                set { mPassword = value; }
            }
            public OnSignInEventArgs(string email, string password) : base()
            {
                Email = email;
                Password = password;
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.SignInDialog, container, false);

            mtxtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            mtxtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            Button mSignUpButton = view.FindViewById<Button>(Resource.Id.btnDialog);

            mSignUpButton.Click += mSignUpButton_Click;

            return view;
        }

        private void mSignUpButton_Click(object sender, EventArgs e)
        {
            //Upon clicking Sign in button
            mOnSignInEvent.Invoke(this, new OnSignInEventArgs(mtxtEmail.Text, mtxtPassword.Text));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
        }
    }
}