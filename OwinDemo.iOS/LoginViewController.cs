using Foundation;
using System;
using System.CodeDom.Compiler;
using CoreGraphics;
using OwinDemo.Business.Models;
using ServiceLibrary;
using UIKit;

namespace OwinDemo.iOS
{
	partial class LoginViewController : UIViewController
	{
		public LoginViewController (IntPtr handle) : base (handle)
		{
		}

        async partial void btnLogin_TouchUpInside(UIButton sender)
        {
            lblLogginError.Text = "checking credentials, please wait ...";
            lblLogginError.TextColor = UIColor.Blue;

            UserLoginModel model = new UserLoginModel(txtUsername.Text, txtPassword.Text);

            if (!model.IsValid())
            {
                return;
            }

            ServiceWrapper serviceWrapper = new ServiceWrapper();
            
            UserSettings.RefreshAuthenticationToken(serviceWrapper);
            TokenModel tokenModel = await serviceWrapper.GetAuthorizationTokenData();
            bool authenticationResult = await serviceWrapper.ValidateUser(model, tokenModel.access_token);

            if (authenticationResult)
            {
                var loggedInController = this.Storyboard.InstantiateViewController("LoggedInSBController");
                if (loggedInController != null)
                {
                    this.NavigationController.PushViewController(loggedInController, true);
                }  
            }
            else
            {
                lblLogginError.Text = "Invalid credentials";
                lblLogginError.TextColor = UIColor.Red;
            }
        }
	}
}
