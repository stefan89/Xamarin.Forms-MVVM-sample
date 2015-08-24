using Xamarin.Forms;

namespace XFdemo
{
	public class App : Application
	{
		public App ()
		{
			DependencyService.Register<NavigationService, NavigationService> ();
			DependencyService.Register<MessageVisualizerService, MessageVisualizerService> ();

			var navigationPage = new NavigationPage (new TodoItemsContentPage ());

			MainPage = navigationPage;
		}
	}
}