using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XFdemo
{
    public class NavigationService
	{
		public static Page CurrentModalPage { 
			get { 
				return CurrentMainPage.Navigation.ModalStack.Count > 0 ? CurrentMainPage.Navigation.ModalStack.LastOrDefault () : null; 
			} 
		}

		public static Page CurrentMainPage { 
			get {
				if(Application.Current.MainPage is TabbedPage){ //Fix for tabbed page navigation 

					TabbedPage currentMainPage = (TabbedPage)Application.Current.MainPage;

					return currentMainPage.CurrentPage;
				}else {
					return Application.Current.MainPage;
				}
			}
		}

		public async Task GoToPage (Page page,  bool animate = true)
        {
			await CurrentMainPage.Navigation.PushAsync (page, animate);
        }

		public async Task GoToModalPage (Page page, bool animate = true)
		{
			await CurrentMainPage.Navigation.PushModalAsync (page, animate);
		}

		public async Task PopCurrentModalPage (bool animate = true)
		{
			if (CurrentModalPage != null) {
				await CurrentModalPage.Navigation.PopModalAsync (animate);
			}
		}

		public async Task PopCurrentPage (bool animate = true)
		{
			if (CurrentMainPage != null) {
				await CurrentMainPage.Navigation.PopAsync (animate);
			}
		}

		public async Task PopBackgroundEnteredPage ()
		{
//			if (CurrentModalPage != null) {
//				if(CurrentModalPage.GetType () == typeof(BackgroundEnteredPage))
//					await CurrentModalPage.Navigation.PopModalAsync (false);
//			}

			await CurrentModalPage.Navigation.PopModalAsync (false);
		}
	}
}