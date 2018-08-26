using System;
using System.Threading.Tasks;
using FirebaseXamarinApp.Model;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;

namespace FirebaseXamarinApp.Services
{
    public class EmployeeService
    {
        private const string firebaseURL = "https://myfirstapp-3a4a3.firebaseio.com/";
        FirebaseClient firebaseclient = new FirebaseClient(firebaseURL);

        public async Task<bool> Add(Employee e)
        {
            try
            {
                //Add Employee
                var item = await firebaseclient.Child("Employees").PostAsync<Employee>(e);
                return true;
            }
            catch(Exception)
            {
                throw;
            }           
        }

        public async Task<bool> Update(string uid, Employee e)
        {
            try
            {
                //Update Employee
                await firebaseclient.Child("Employees").Child(uid).Child("empcode").PostAsync(e.empcode);
                await firebaseclient.Child("Employees").Child(uid).Child("name").PostAsync(e.name);
                await firebaseclient.Child("Employees").Child(uid).Child("surname").PostAsync(e.surname);
                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(string uid)
        {
            try
            {
                //Delete Employee
                await firebaseclient.Child("Employees").Child(uid).DeleteAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}