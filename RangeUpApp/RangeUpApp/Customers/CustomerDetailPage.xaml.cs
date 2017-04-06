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
	public partial class CustomerDetailPage : ContentPage
	{
        private Customer customer;

        public CustomerDetailPage ()
		{
			InitializeComponent ();
            GunTypePicker.SelectedIndexChanged += this.myPickerSelectedIndexChanged;

            //var selectedValue = GunTypePicker.Items[GunTypePicker.SelectedIndex];
        }

        public CustomerDetailPage(Customer customer)
        {
            this.customer = customer;
            InitializeComponent();
            GunTypePicker.SelectedIndexChanged += this.myPickerSelectedIndexChanged;
            CustomerName.Text = this.customer.Name;
            CurrentGun.Text = "Current Gun is " + this.customer.GunType;
        }

        public void myPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            //Method call every time when picker selection changed.
            var selectedValue = GunTypePicker.Items[GunTypePicker.SelectedIndex];
            DisplayAlert("Alert", selectedValue, "OK");
        }


        public void myStepperChanged(object sender, ValueChangedEventArgs e)
        {
            myTime.Text = Convert.ToString(e.NewValue) + "min";
        }
    }

  
}
