using Android.App;
using Android.Widget;
using Android.OS;

namespace Hackathon_App
{
    [Activity(Label = "Hackathon_App", MainLauncher = true, Icon = "@drawable/LOGO")]
    public class MainActivity : Activity
    {
        private Button mSignInButton;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mSignInButton = FindViewById<Button> (Resource.Id.SignInButton);
            mSignInButton.Click += mSignInButton_Click;
        }

        //Sign In dialog
        private void mSignInButton_Click(object sender, System.EventArgs e)
        {
            FragmentTransaction SItransaction = FragmentManager.BeginTransaction();
            SignInDialog mSignInDialog = new SignInDialog();
            mSignInDialog.Show(SItransaction, "dialog fragment");

            mSignInDialog.mOnSignInEvent += mSignInDialog_mOnSignInEvent;
        }


        private void mSignInDialog_mOnSignInEvent(object sender, SignInDialog.OnSignInEventArgs e)
        {
            StartActivity(typeof(MenuActivity));
        }

    }
}

