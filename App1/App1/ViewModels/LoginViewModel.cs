using App1.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using App1.Services;
using App1.Models;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace App1.ViewModels
{
    [QueryProperty(nameof(Text), "text")]
    public class LoginViewModel : BaseViewModel
    {
        public ObservableCollection<MyBooks> Books { get; set; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command OpenMenuCommand { get; }
        public Command SelectMyBooksListItemCommand { get; }
        public string SearchTerm { get; set; }
        public Command SearchBarCommand { get; }
        public string Text { get; set; }

        public class MyBooks: ObservableCollection<MyBook>
        {
            public string Name { get; private set; }
            public MyBooks(string name)
                :base()
            {
                Name = name;
            }
            public MyBooks(string name, IEnumerable<MyBook> books)
                : base(books)
            {
                Name = name;
            }
        }

        public LoginViewModel()
        {
            Books = new ObservableCollection<MyBooks>();
            LoadItemsCommand = new Command(ExecuteLoadItemsCommand);
            SelectMyBooksListItemCommand = new Command(OnSelectMyBooksListItem);
            AddItemCommand = new Command(OnAddItem);
            OpenMenuCommand = new Command(OnOpenMenu);
        }

        private void ExecuteLoadItemsCommand()
        {  
            try
            {
                Books.Clear();
                List<MyBook> temp = App.Database.GetItems().ToList();
                List<string> authors = temp.Select(p => p.Author).Distinct().ToList();
                authors.Sort();

                foreach (string a in authors)
                {
                    Books.Add(new MyBooks(a, temp.Where(b => b.Author == a).OrderBy(b => b.Title)));
                }             
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public void OnAppearing()
        {
            ExecuteLoadItemsCommand();
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        private async void OnSelectMyBooksListItem(object obj)
        {
            //Book book = (Book)obj;
            await App.Current.MainPage.DisplayAlert("Автор", "Книга", "Ok");
        }

        private async void OnOpenMenu(object obj)
        {
            MyBook book = (MyBook)obj;
            Debug.WriteLine(book.Title);
        }
    }
}
