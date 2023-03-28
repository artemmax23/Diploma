using App1.Models;
using App1.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using App1.Services;
using System.Collections.Generic;

namespace App1.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Book> Books { get; }
        public Command LoadItemsCommand { get; }
        public string SearchTerm { get; set; }
        public Command SearchBarCommand { get; }

        public ItemsViewModel()
        {
            Title = "Список избранного";
            Books = new ObservableCollection<Book>();
            LoadItemsCommand = new Command(ExecuteLoadItemsCommand);
        }

        private void ExecuteLoadItemsCommand()
        {
            try
            {
                Books.Clear();
                List<Book> temp = new List<Book>();
                Book book = new Book
                {
                    title = "1984",
                    author = "Оруэлл Дж.",
                    averageCost = 40.50f,
                };
                temp.Add(book);
                temp.Add(book);
                temp.Add(book);
                temp.Add(book);
                temp.Add(book);
                temp.Add(book);
                temp.Add(book);
                temp.Add(book);
                temp.ForEach(Books.Add);
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

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}