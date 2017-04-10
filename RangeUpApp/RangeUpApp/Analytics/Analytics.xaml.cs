using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RangeUpApp.Customers;


namespace RangeUpApp.Analytics
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Analytics : ContentPage
	{
		public Analytics ()
		{
			InitializeComponent ();

            fillfields();
		}

        private void fillfields()
        {

            TotalnumberOfClientsToday.Text = Convert.ToString(CustomersCollectionHolder.customers.Count);
        }
    }
}
