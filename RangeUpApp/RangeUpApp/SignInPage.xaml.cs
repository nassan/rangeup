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
	public partial class SignInPage : ContentPage
	{

        private bool isRememberMe = false;

		public SignInPage(){
			InitializeComponent ();
		}

        async void OnSignInbuttonClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);

            if (isValid)
            {
                // When Sign In Button pressed - save 'remember me' choice
                Application.Current.Properties[App.IsRememberMePressedConst] = isRememberMe;

                // open new windows
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();
            } else
            {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }

        }
        

        private bool AreCredentialsCorrect(User user)
        {
            // If findInDb(user.Username, user.Password) == true
            // return true; else false;
            // need to send data synch(!) to server in json
            return true;

        }
        
        private void OnSwitchToggle(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                isRememberMe = true;
            }
            else
            {
                isRememberMe = false;
            }
        }
    }
}
