using Android.App;
using Android.OS;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace FirebaseXamarinApp.Activities
{
    [Activity(Label = "BaseActivity")]
    public class BaseActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }

        public void ConfigureToolbar(int toolbarId)
        {
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(toolbarId);

            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
        }
    }
}