using App1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string title;
        private string author;
        private string comment;
        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(title)
                && !String.IsNullOrWhiteSpace(author);
        }

        public string Text
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string Comment
        {
            get => comment;
            set => SetProperty(ref author, value);
        }

        public string Author
        {
            get => author;
            set => SetProperty(ref author, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            /*Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description
            };

            await DataStore.AddItemAsync(newItem);*/

            App.Database.SaveItem(new MyBook()
            {
                Title = title,
                Author = author,
                Comments = comment
            });
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync($"..");
        }
    }
}
