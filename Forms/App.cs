using Xamarin.Forms;

namespace XFdemo
{
	public class App : Application
	{
		public App ()
		{
			var navigationPage = new NavigationPage (new TodoItemsContentPage ());

			MainPage = navigationPage;
		}
	}
}