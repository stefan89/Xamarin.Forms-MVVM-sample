using Android.OS;
using Android.App;
using Android.Content.PM;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace XFdemo.Droid
{
	[Activity (Label = "XFdemo.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			Forms.Init (this, bundle);

			LoadApplication (new App ());
		}
	}
}