using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Firebase.Xamarin.Database;
using FirebaseXamarinApp.Adapters;
using FirebaseXamarinApp.Model;
using FirebaseXamarinApp.Services;

namespace FirebaseXamarinApp.Activities
{
    [Activity(Label = "EmployeesActivity", MainLauncher = true)]
    public class EmployeesActivity : BaseActivity
    {
        EmployeesRecyclerAdapter employeesRecyclerAdapter;
        EmployeeService _employeeService;

        private EditText _empcode;
        private EditText _name;
        private EditText _surname;
        private Button _addButton;
        private CoordinatorLayout _layout;

        private const string firebaseURL = "https://myfirstapp-3a4a3.firebaseio.com/";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.employees);

            _layout = FindViewById<CoordinatorLayout>(Resource.Id.layout_employees);

            //Register Service Classes
            _employeeService = new EmployeeService();

            _empcode = FindViewById<EditText>(Resource.Id.empcode);
            _name = FindViewById<EditText>(Resource.Id.name);
            _surname = FindViewById<EditText>(Resource.Id.surname);

            _addButton = FindViewById<Button>(Resource.Id.btn_add_employee);
            _addButton.Click += AddEmpClicked;

            InitializeDisplayContentAsync();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.employee_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.emp_add:
                    AddEmployeeAsync();
                    return true;
                case Resource.Id.emp_edit:
                    EditEmployee();
                    return true;
                case Resource.Id.emp_delete:
                    DeleteEmployee();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public async void AddEmployeeAsync()
        {
            try
            {
                Employee e = new Employee()
                {
                    empcode = _empcode.Text,
                    name = _name.Text,
                    surname = _surname.Text
                };

                var result = await _employeeService.Add(e);

                Toast.MakeText(this, "Employee Successfully Added", ToastLength.Long).Show();
            }
            catch (Exception)
            {
                Toast.MakeText(this, "Error", ToastLength.Long).Show();
            }
        }

        public void EditEmployee()
        {
            try
            {

            }
            catch (Exception)
            {
                Toast.MakeText(this, "Error", ToastLength.Long).Show();
            }
        }

        public void DeleteEmployee()
        {
            try
            {

            }
            catch (Exception)
            {
                Toast.MakeText(this, "Error", ToastLength.Long).Show();
            }
        }

        private void AddEmpClicked(object sender, EventArgs args)
        {
            AddEmployeeAsync();

            Snackbar.Make(_layout, "Employee Successfully Added.", Snackbar.LengthLong)
                .SetAction("OK", (v) => { })
                .Show();
        }

        private async void InitializeDisplayContentAsync()
        {
            RecyclerView recyclerNotes = FindViewById<RecyclerView>(Resource.Id.list_employees);
            LinearLayoutManager notesLayoutManager = new LinearLayoutManager(this);
            recyclerNotes.SetLayoutManager(notesLayoutManager);

            var firebase = new FirebaseClient(firebaseURL);
            var items = await firebase.Child("Employees").OnceAsync<Employee>();

            List<Employee> emps = new List<Employee>();

            foreach (var item in items)
            {
                Employee emp = new Employee()
                {
                    empcode = item.Object.empcode,
                    name = item.Object.name,
                    surname = item.Object.surname
                };

                emps.Add(emp);
            }

            employeesRecyclerAdapter = new EmployeesRecyclerAdapter(this, emps);
            recyclerNotes.SetAdapter(employeesRecyclerAdapter);
        }
    }
}