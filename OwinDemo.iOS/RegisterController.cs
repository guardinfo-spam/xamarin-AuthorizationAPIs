using Foundation;
using System;
using System.CodeDom.Compiler;
using OwinDemo.Business.Models;
using ServiceLibrary;
using UIKit;

namespace OwinDemo.iOS
{
	partial class RegisterController : UIViewController
	{
		public RegisterController (IntPtr handle) : base (handle)
		{
		}

        async partial void btnRegister_TouchUpInside(UIButton sender)
        {
            lblRegisterFormFeedback.Text = "contacting API, please wait ...";
            lblRegisterFormFeedback.TextColor = UIColor.Blue;

            UserLoginModel model = new UserLoginModel(txtRegisterUsername.Text, txtRegisterPassword.Text);

            if (!model.IsValid())
            {
                lblRegisterFormFeedback.Text = "please fill in your details";
                lblRegisterFormFeedback.TextColor = UIColor.Red;
                return;
            }

            ServiceWrapper serviceWrapper = new ServiceWrapper();

            TokenModel tokenModel = await serviceWrapper.GetAuthorizationTokenData();
            string authenticationResult = await serviceWrapper.RegisterUser(model, tokenModel.access_token);

            lblRegisterFormFeedback.Text = authenticationResult;
            lblRegisterFormFeedback.TextColor = UIColor.Blue;
            
        }
	}
}
