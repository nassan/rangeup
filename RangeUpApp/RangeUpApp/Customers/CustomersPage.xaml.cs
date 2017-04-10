using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using RangeUpApp.Gun;


namespace RangeUpApp.Customers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomersPage : ContentPage
    {
        
        public CustomersPage ()
		{
			InitializeComponent ();

            // Bind data with list
            CustomersView.ItemsSource = CustomersCollectionHolder.customers;

        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                ((ListView)sender).SelectedItem = null;
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }

            int number =  (e.SelectedItem as Customer).number;
            
            Customer customer = findCustomerByNumber(number);
            Navigation.PushAsync(new CustomerDetailPage(customer));

            // DisplayAlert("Tapped", res + " row was selected", "OK");
        }

        //let an item be unselected (on tap)
        void OnItemTapped (object sender, ItemTappedEventArgs e) {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            ((ListView)sender).SelectedItem = null; // de-select the row
        }

        // on more will show some customer's analytics
        public void OnMore(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            int number = Convert.ToInt32(mi.CommandParameter);
            Customer customer = findCustomerByNumber(number);
        }
        

        private Customer findCustomerByNumber(int number)
        {
            for (int i = 0; i < CustomersCollectionHolder.customers.Count; i++)
            {
                if (CustomersCollectionHolder.customers[i].number == number)
                {
                    return CustomersCollectionHolder.customers[i];
                }
            }
            return null;
        }


        public async void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            int number = Convert.ToInt32(mi.CommandParameter);
            for (int i = 0; i < CustomersCollectionHolder.customers.Count; i++)
            {
                if (CustomersCollectionHolder.customers[i].number == number)
                {
                    var action = await DisplayAlert("The Customer " + CustomersCollectionHolder.customers[i].Name,  
                        "will be removed" , "Yes", "No");
                    if (action)
                    {
                        CustomersCollectionHolder.customers.RemoveAt(i);                        
                    } else
                    {
                        await DisplayAlert("The Customer " + CustomersCollectionHolder.customers[i].Name, 
                            "hasn't been removed", "ok");
                    }
                    break;
                }
            }
            
        }

    }
}
