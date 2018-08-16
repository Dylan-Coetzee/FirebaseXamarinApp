using System;
using System.Collections.Generic;
using System.Linq;
using Android;
using Android.Content;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using FirebaseXamarinApp.Model;

namespace FirebaseXamarinApp.Adapters
{
    public class EmployeesRecyclerAdapter : RecyclerView.Adapter
    {
        private Context mContent;
        private LayoutInflater mLayoutInflater;
        private List<Employee> mEmployees;
        public event System.EventHandler<int> ItemClick;
        static Random rand = new Random();

        public EmployeesRecyclerAdapter(Context context, List<Employee> employees)
        {
            mContent = context;
            mEmployees = employees;
            mLayoutInflater = LayoutInflater.From(context);
        }

        public override int ItemCount => mEmployees.Count();

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {   //Call the and decide what data to display in the view
            Employee emp = mEmployees[position];
            var vh = holder as ViewHolder;

            vh.Image.SetImageResource(Resource.Drawable.circle);
            vh.Letter.Text = emp.name.Substring(0, 1).ToUpper();
            vh.Name.Text = emp.name + " " + emp.surname;
            vh.Code.Text = emp.empcode;
            vh.EmpPosition.Text = "EMPLOYEE";
            vh.mCurrentPosition = position;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {   //Inflates the view and how to get to the views
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_employee_list, parent, false);
            return new ViewHolder(view, OnClick);
        }

        //Class to store data, can be create outside the adapter, but will only be use by the adapter
        public class ViewHolder : RecyclerView.ViewHolder
        {
            public ImageView Image;
            public TextView Name;
            public TextView Code;
            public TextView Letter;
            public TextView EmpPosition;

            public int mCurrentPosition;

            public ViewHolder(View itemView, System.Action<int> listener)
                : base(itemView) // Keeps reference to each view
            {
                Image = itemView.FindViewById<ImageView>(Resource.Id.imageColor);
                Letter = itemView.FindViewById<TextView>(Resource.Id.textLetter);
                Name = itemView.FindViewById<TextView>(Resource.Id.textEmpName);
                Code = itemView.FindViewById<TextView>(Resource.Id.textEmpCode);
                EmpPosition = itemView.FindViewById<TextView>(Resource.Id.textEmpPosition);

                itemView.Click += (sender, e) => listener(base.LayoutPosition);
            }
        }

        void OnClick(int position)
        {
            if (ItemClick != null)
                ItemClick(this, position);
        }


        public static Color GetRandomColor()
        {
            int hue = rand.Next(255);
            Color color = Color.HSVToColor(
                new[] {
            hue,
            1.0f,
            1.0f,
                }
            );
            return color;
        }
    }
}