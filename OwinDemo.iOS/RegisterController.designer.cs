// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace OwinDemo.iOS
{
	[Register ("RegisterController")]
	partial class RegisterController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnRegister { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblRegisterFormFeedback { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblRegisterPassword { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblRegisterUsername { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtRegisterPassword { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtRegisterUsername { get; set; }

		[Action ("btnRegister_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnRegister_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnRegister != null) {
				btnRegister.Dispose ();
				btnRegister = null;
			}
			if (lblRegisterFormFeedback != null) {
				lblRegisterFormFeedback.Dispose ();
				lblRegisterFormFeedback = null;
			}
			if (lblRegisterPassword != null) {
				lblRegisterPassword.Dispose ();
				lblRegisterPassword = null;
			}
			if (lblRegisterUsername != null) {
				lblRegisterUsername.Dispose ();
				lblRegisterUsername = null;
			}
			if (txtRegisterPassword != null) {
				txtRegisterPassword.Dispose ();
				txtRegisterPassword = null;
			}
			if (txtRegisterUsername != null) {
				txtRegisterUsername.Dispose ();
				txtRegisterUsername = null;
			}
		}
	}
}
