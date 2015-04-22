using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
//using Newtonsoft.Json;
using Org.Json;
using ServiceLibrary;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            TextView message = FindViewById<TextView>(Resource.Id.textView1);

            message.Text = "system waiting";

            ServiceWrapper sw = new ServiceWrapper();

            button.Click += async (sender, e) =>
            {
                message.Text = "Firing call to the Authorization Server";
                TokenModel tokenModel = await sw.GetAuthorizationTokenData();
                //var tokenData = JsonConvert.DeserializeObject<dynamic>(content);
                //var token = tokenData.access_token.ToString();

                message.Text = "token received : " + tokenModel.access_token;
            };
        }

        
    }
}

