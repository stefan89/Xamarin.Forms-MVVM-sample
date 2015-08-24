using System.Threading.Tasks;

using Xamarin.Forms;

namespace XFdemo
{
    public class MessageVisualizerService
    {
        public async Task<bool> ShowMessage (string title, string message, string ok, string cancel=null)
        {
            if (cancel == null) {
				Device.BeginInvokeOnMainThread (async ()=>{
                	await Application.Current.MainPage.DisplayAlert(title, message, ok);
				});
                return true;
            }

            return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        }

		public async Task<string> ShowActionSheet (string title, string option1, string option2, string cancel=null)
		{
			if (cancel == null) {
				return await Application.Current.MainPage.DisplayActionSheet (title, cancel, null, option1, option2);
			}

			return await Application.Current.MainPage.DisplayActionSheet (title, cancel, null, option1, option2);
		}
    }
}