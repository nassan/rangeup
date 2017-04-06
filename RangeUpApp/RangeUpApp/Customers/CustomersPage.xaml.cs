using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace RangeUpApp.Customers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomersPage : ContentPage
	{
        ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

        public CustomersPage ()
		{
			InitializeComponent ();

            // 1. Download list (in json) of all customers and save it in list of class 
            downloadCustomers();

            // 2.Populate list
            CustomersView.ItemsSource = customers;

        }

        private void downloadCustomers()
        {
            for (int i = 0; i<20; i++)
            {
                Customer c = new Customer("Customer " + i, "GunType " + i, "30");
                customers.Add(c);
            }
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                ((ListView)sender).SelectedItem = null;
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }

            // Open New Window for detail view of customer
            Navigation.PushAsync(new CustomerDetailPage());
        }

        public void OnMore(object sender, EventArgs e)
        {
            openDetailedCustomerPage(sender);
        }

        public void openDetailedCustomerPage(object sender)
        {
            var mi = ((MenuItem)sender);
            string number = Convert.ToString(mi.CommandParameter);
            Customer customer = findCustomerByNumber(number);
            Navigation.PushAsync(new CustomerDetailPage(customer));
        }

        private Customer findCustomerByNumber(string number)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                if (Convert.ToString(customers[i].number).Equals(number))
                {
                    return customers[i];
                }
            }
            return null;
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            string number = Convert.ToString(mi.CommandParameter);
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers[i].number.Equals(number))
                {
                    customers.RemoveAt(i);
                    break;
                }
            }
            DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
        }


    }
}
