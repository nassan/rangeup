using RangeUpApp.Gun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RangeUpApp.Customers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddNewCustomerPage : ContentPage
	{

        Customer customer; 
		public AddNewCustomerPage ()
		{
			InitializeComponent ();

            customer = new Customer();

            gunType.SelectedIndex = 0;


        }

        public void OnTimeChanged(object sender, TextChangedEventArgs e)
        {
            labelTime.Text = Convert.ToString(TimeStepper.Value);
        }

        public void onSaveBtnClicked(object sender, TextChangedEventArgs e)
        {
            // check name
            if (string.IsNullOrWhiteSpace(name.Text))
            {
                return;
            }

            // Get Fields
            string customerName = name.Text;
            string customerGunType = GunClass.guns[gunType.SelectedIndex];
            string customerTime = Convert.ToString(TimeStepper.Value);


        }
    }
}
