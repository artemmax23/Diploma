using System;
using System.Windows.Input;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using App1.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using App1.Views;

namespace App1.ViewModels
{
    [QueryProperty(nameof(Name), "Name")]
    [QueryProperty(nameof(Author), "Author")]
    [QueryProperty(nameof(PubHouse), "Pubhouse")]
    [QueryProperty(nameof(Seria), "Seria")]
    [QueryProperty(nameof(PriceFrom), "PriceFrom")]
    [QueryProperty(nameof(PriceTo), "PriceTo")]
    [QueryProperty(nameof(SearchBool), "Search")]
    public class AboutViewModel : BaseViewModel
    {
        RestService service;
        public ObservableCollection<Book> Books { get; private set; }
        public string SearchTerm { get; set; }
        public Command SearchBarCommand { get; }
        public Command OpenAdvancedSearch { get; }
        public Command OpenSort { get; }

        public string Name { get; set; }
        public string Author { get; set; }
        public string PubHouse { get; set; }
        public string Seria { get; set; }
        public string PriceFrom { get; set; }
        public string PriceTo { get; set; }
        public bool SearchBool { get; set; } = false;

        public AboutViewModel()
        {
            Title = "Поиск";
            service = new RestService();
            Books = new ObservableCollection<Book>();
            SearchBarCommand = new Command(Search);
            OpenAdvancedSearch = new Command(AdvancedSearch);
            OpenSort = new Command(Sort);
            IsBusy = false;
        }

        private async void Search()
        {
            Books.Clear();
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                //List<Book> temp = await service.GetBooks(SearchTerm);
                List<Book> temp = new List<Book>();
                Book book = new Book();
                book.title = "1984";
                book.author = "Дж. Оруэлл";
                book.pubhouse = "Эксмо";
                book.averageCost = 400.50f;
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
            Debug.WriteLine("Load success!");
            //Debug.WriteLine(Books.Count);
            Debug.WriteLine(Name);
            Debug.WriteLine(Author);
            Debug.WriteLine(PubHouse);
            Debug.WriteLine(Seria);
            Debug.WriteLine(PriceFrom);
            Debug.WriteLine(PriceTo);
        }

        public void OnAppearing()
        {
            if (SearchBool)
            {
                Debug.WriteLine("vdfbcgvnhhfbgdfvscvgbfh");
                SearchBool = false;
            }
        }

        private async void AdvancedSearch()
        {
            string text = SearchTerm;
            await Shell.Current.GoToAsync($"Filter?Name={text}");
        }

        private async void Sort()
        {
            await Shell.Current.GoToAsync(nameof(SortPage));
        }
    }
}