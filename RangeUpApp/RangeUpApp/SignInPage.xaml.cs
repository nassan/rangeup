using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

// My Libraries
using RestSharp;
using Newtonsoft.Json;


namespace RangeUpApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignInPage : ContentPage
	{

        private bool isRememberMe = false;
        private string SERVER = "http://10.0.2.2:3002";

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
                       
            ValidationAndType validationAndType = AreCredentialsCorrect(user);

            if (validationAndType.isValid)
            {
                // When Sign In Button pressed - save 'remember me' choice
                Application.Current.Properties[App.IsRememberMePressedConst] = isRememberMe;

                // open new windows master for master, field for filed
                if ("Master".Equals(validationAndType.type))
                {
                    await Navigation.PushModalAsync(new MasterPage());

                }
                else if ("Filed".Equals(validationAndType.type))
                {
                    //await Navigation.PushModalAsync(new FieldPage());
                }
                else
                {
                    messageLabel.Text = "Problem has been occured in the server";
                }
                
            } else
            {
                messageLabel.Text = "SignIn failed. Please fill the username and password";
                passwordEntry.Text = string.Empty;
            }

        }
        

        private ValidationAndType AreCredentialsCorrect(User user)
        {
            // If findInDb(user.Username, user.Password) == true
            // return true; else false;
            // need to send data synch(!) to server in json

            // Check fields not null
            //if (string.IsNullOrWhiteSpace(user.Username) ||
            //        string.IsNullOrWhiteSpace(user.Password)) {
            //    return new ValidationAndType() { isValid = false, type = "" }; ;
            //}

            // prepare Client
            //var client = new RestClient();

            //// set url to the server
            //client.BaseUrl = new Uri(SERVER);

            //// prepare request
            //var request = new RestRequest();
            //request.Method = Method.POST;
            //request.AddHeader("Accept", "application/json");
            //request.Parameters.Clear(); // what is for? works - fine
            //request.RequestFormat = DataFormat.Json;
            //request.AddJsonBody(user);

            ////execute --- it's sych? not' sure 100%
            //IRestResponse response = client.Execute(request);

            return new ValidationAndType () { isValid = true, type = "Master" };
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

    internal class ValidationAndType
    {
        public ValidationAndType()
        {
        }

        public bool isValid { get; set; }
        public string type { get; set; }
    }
}
