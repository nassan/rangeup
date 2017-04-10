using RangeUpApp.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace RangeUpApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : MasterDetailPage
    {
        public List<MasterPageNavigationalItem> menuList { get; set; }

        public MasterPage ()
		{
			InitializeComponent ();

            // initiate a list contains all menus 
            menuList = new List<MasterPageNavigationalItem>();

            // 1. Customers Page
            var customers = new MasterPageNavigationalItem()
            { Title = "Customers", TargetType = typeof(Customers.CustomersPage) };

            // generate pseudo-collection
            CustomersCollectionHolder.generateRandCollection();

            // 2. Analytics Page
            var analytics = new MasterPageNavigationalItem()
            { Title = "Analytics",  TargetType = typeof(Analytics.Analytics) };

            // 3. Add new Customer Page - FloatAction Button (Fab doesn't work!)
            var addNewCustomer = new MasterPageNavigationalItem()
            { Title = "Add New customer",  TargetType = typeof(Customers.AddNewCustomerPage) };

            // Append them to the list
            menuList.Add(customers);
            menuList.Add(analytics);
            menuList.Add(addNewCustomer);

            // Bind data
            navigationDrawerList.ItemsSource = menuList;

            // Set initial Page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Customers.CustomersPage)));

        }

        // When press om hamburger icon
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // magic, magic and open what we need
            var item = (MasterPageNavigationalItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }

      
    }

   
}
