using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using RangeUpApp.Gun;


namespace RangeUpApp.Customers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomerDetailPage : ContentPage
	{
        private Customer customer;


        public CustomerDetailPage ()
		{
			InitializeComponent ();

            //var selectedValue = GunTypePicker.Items[GunTypePicker.SelectedIndex];
        }

        public CustomerDetailPage(Customer customer)
        {
            this.customer = customer;
            InitializeComponent();
            fillAllFiled();
           
        }

       
        public void OnNameChanged(object sender, TextChangedEventArgs e)
        {
            customer.Name = NameEditor.Text;
            
        }

        public void OnGunChanged(object sender, TextChangedEventArgs e)
        {
            customer.GunType =  GunClass.guns[NewGunBindablePicker.SelectedIndex];
               
        }

        public void onNewTimeButtonClicked(object sender, TextChangedEventArgs e)
        {
            // how much time left + new time
            // How Much time have passed
            TimeSpan tmp = DateTime.Now.Subtract(customer.StartTime);

            // And How much time left for customer
            TimeSpan leftTime = TimeSpan.FromMinutes(Convert.ToInt32(customer.Time)).Subtract(tmp);

            int newValue = Convert.ToInt32(TimeLabelValue.Text);
            int newTime = (int)leftTime.TotalMinutes + newValue;

            // change time property
            customer.Time = Convert.ToString(newTime);

            // change starttime property
            customer.StartTime = DateTime.Now;
            fillAllFiled();
        }

        public void onStepperChanged(object sender, TextChangedEventArgs e)
        {
            TimeLabelValue.Text = Convert.ToString(TimeStepper.Value);
        }

        
        private void fillAllFiled()
        {
            // Name
            NameEditor.Text = customer.Name;

            // Gun
            NewGunBindablePicker.ItemsSource = GunClass.guns;
            NewGunBindablePicker.SelectedItem = customer.GunType;

            //Time
            //TimeEditor.Text = customer.Time;
            TimeLabelValue.Text = customer.Time;

            //Time Left
            double TimePassed = (DateTime.Now - customer.StartTime).TotalMinutes;
            if (TimeSpan.FromMinutes(Convert.ToInt32(customer.Time)).TotalMinutes > TimePassed)
            {
                // e.g. Customer still has it's time

                // start timer
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    // How Much time have passed
                    TimeSpan tmp = DateTime.Now.Subtract(customer.StartTime);

                    // And How much time left for customer
                    TimeSpan leftTime = TimeSpan.FromMinutes(Convert.ToInt32(customer.Time)).Subtract(tmp);

                    // Beauty f*cking magic
                    var formatted = string.Format("{0:hh\\:mm\\:ss}", leftTime);

                    // How i happy that it works
                    TimeLeft.Text = formatted;

                    // true for repeat
                    if (leftTime.TotalMilliseconds < 0)
                    {
                        return false;
                    } else
                    {
                        return true;
                    }
                });
            }
            else
            {
                // Bye-bye
                TimeLeft.Text = "time's up";
            }
        }

        
    }

  
}
