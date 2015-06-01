using UIKit;
using Foundation;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace XFdemo.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Forms.Init ();

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}