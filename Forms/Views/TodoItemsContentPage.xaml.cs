using Xamarin.Forms;

namespace XFdemo
{
	public partial class TodoItemsContentPage : ContentPage
	{
		public TodoItemsContentPage ()
		{
			InitializeComponent ();

			BindingContext = new TodoItemsViewModel ();
		}
	}
}