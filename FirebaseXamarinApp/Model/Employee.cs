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

namespace FirebaseXamarinApp.Model
{
    public class Employee
    {
        public string empcode { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
    }
}