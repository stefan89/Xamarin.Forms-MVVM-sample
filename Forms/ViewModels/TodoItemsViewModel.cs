using System.Diagnostics;
using System.Windows.Input;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace XFdemo
{
	public class TodoItemsViewModel : BaseViewModel
	{
		public ICommand RefreshListCommand { 
			get {
				return new Command (() => {
					TodoItems.Add (new TodoItem { Name = "Pull to refresh item", Description = "Demo item"});
					IsRefreshing = false;
				});
			}
		}

		public ICommand AddNewTodoCommand {
			get {
				return new Command (() => {
					TodoItems.Add (new TodoItem { Name = "Button clicked item", Description = "Demo item"});
				});
			}
		}

		public ICommand NavigateToSecondPageCommand {
			get {
				return new Command (async() => {
					await DependencyService.Get<NavigationService>().GoToPage (new SecondContentPage());
				});
			}
		}

		bool _isRefreshing;
		public bool IsRefreshing {
			get {
				return _isRefreshing;
			}
			set {
				if (_isRefreshing != value) {
					_isRefreshing = value;
					RaisePropertyChanged ();
				}
			}
		}

		TodoItem _selectedTodoItem;
		public TodoItem SelectedTodoItem {
			get {
				return _selectedTodoItem;
			}
			set {
				if (_selectedTodoItem != value) {
					_selectedTodoItem = value;
					RaisePropertyChanged ();
					HandleItemSelected (_selectedTodoItem);
				}
			}
		}

		public ObservableCollection<TodoItem> TodoItems { get; set; }

		public TodoItemsViewModel ()
		{
			TodoItems = new ObservableCollection<TodoItem> { 
				new TodoItem { Name = "Afwas", 				Description = "Witte was doen" },
				new TodoItem { Name = "Stofzuigen", 		Description = "Slaapkamers stofzuigen" },
				new TodoItem { Name = "Olie pijlen", 		Description = "Olie pijlen van auto" },
				new TodoItem { Name = "Rekeningen betalen", Description = "Openstaande rekeningen betalen" },
				new TodoItem { Name = "Cadeau kopen", 		Description = "Verjaardagscadeau kopen voor Pietje" }
			};
		}

		async void HandleItemSelected(TodoItem selectedTodoItem)
		{
			await DependencyService.Get<MessageVisualizerService> ().ShowMessage ("Item clicked", selectedTodoItem.Name + " clicked", "OK");
//			Debug.WriteLine (selectedTodoItem.Name + " clicked");
		}
	}
}