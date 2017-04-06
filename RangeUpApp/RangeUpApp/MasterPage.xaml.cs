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

            menuList = new List<MasterPageNavigationalItem>();

            var customers = new MasterPageNavigationalItem()
            { Title = "Customers", TargetType = typeof(Customers.CustomersPage) };
            var page2 = new MasterPageNavigationalItem()
            { Title = "Item 2",  TargetType = typeof(Page1) };
            var page3 = new MasterPageNavigationalItem()
            { Title = "Item 3",  TargetType = typeof(Page1) };

            menuList.Add(customers);
            menuList.Add(page2);
            menuList.Add(page3);

            navigationDrawerList.ItemsSource = menuList;

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Customers.CustomersPage)));

            
            

        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageNavigationalItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }

      
    }

   
}
