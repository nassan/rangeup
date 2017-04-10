using RangeUpApp.Gun;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RangeUpApp.Customers
{

    // Public class holds collection of customers
    public class CustomersCollectionHolder
    {
        public static ObservableCollection<Customer> customers = new ObservableCollection<Customer>();


        // remove later
        public static void generateRandCollection()
        {
            for (int i = 0; i < 20; i++)
            {

                Customer c = new Customer("Customer " + i, GunClass.guns[i], "1");
                customers.Add(c);
            }
        }



    }
}
