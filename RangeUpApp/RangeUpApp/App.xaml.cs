using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace RangeUpApp
{
	public partial class App : Application
	{
        public static string IsRememberMePressedConst = "IsRememberMePressed";


        public App ()
		{
			InitializeComponent();

            // Whether pressed 'Rememeber me'
            if (!IsRememberMePressed()) {
                // Need to sign in
                MainPage = new NavigationPage(new SignInPage());
            }
            else {
                // Need to go directly to the proper screen
                // for Master - master screen
                // for Field - filed screen
            }
			//MainPage = new RangeUpApp.MainPage();
		}

        private bool IsRememberMePressed()
        {
            if (Application.Current.Properties.ContainsKey(IsRememberMePressedConst))
            {
                return (bool) Application.Current.Properties[IsRememberMePressedConst];
            }
            return false;
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}

}
