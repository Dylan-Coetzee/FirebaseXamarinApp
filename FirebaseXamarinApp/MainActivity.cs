﻿using Android.App;
using Android.Widget;
using Android.OS;

namespace FirebaseXamarinApp
{
    [Activity(Label = "FirebaseXamarinApp", MainLauncher = false)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //This is a github test
        }
    }
}

