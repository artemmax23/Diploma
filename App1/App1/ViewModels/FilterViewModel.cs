using App1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;

namespace App1.ViewModels
{
    [QueryProperty(nameof(Name), "Name")]
    class FilterViewModel : BaseViewModel
    {
        private string name;
        private string author;
        private string pubHouse;
        private string seria;
        private string priceFrom;
        private string priceTo;
        public Command ApplyFilterCommand { get; }
        public FilterViewModel()
        {
            ApplyFilterCommand = new Command(ApplyFilter, ValidateFilter);
            PropertyChanged +=
                (_, __) => ApplyFilterCommand.ChangeCanExecute();
        }

        private bool ValidateFilter()
        {
            return !string.IsNullOrWhiteSpace(name)
                && (!string.IsNullOrWhiteSpace(author)
                || !string.IsNullOrWhiteSpace(Seria)
                || !string.IsNullOrWhiteSpace(PubHouse)
                || !string.IsNullOrWhiteSpace(PriceFrom)
                || !string.IsNullOrWhiteSpace(PriceTo));
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Author 
        { 
            get => author; 
            set => SetProperty(ref author, value); 
        }
        public string PubHouse 
        { 
            get => pubHouse;
            set => SetProperty(ref pubHouse, value); 
        }
        public string Seria 
        { 
            get => seria; 
            set => SetProperty(ref seria, value); 
        }
        public string PriceFrom 
        { 
            get => priceFrom; 
            set => SetProperty(ref priceFrom, value); 
        }
        public string PriceTo 
        { 
            get => priceTo; 
            set => SetProperty(ref priceTo, value); 
        }

        private async void ApplyFilter()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(PriceFrom))
                    decimal.Parse(PriceFrom);
                if (!string.IsNullOrWhiteSpace(PriceTo))
                    decimal.Parse(PriceTo);
                if (!string.IsNullOrWhiteSpace(PriceTo) 
                    && !string.IsNullOrWhiteSpace(PriceFrom)
                    && decimal.Parse(PriceFrom) > decimal.Parse(PriceTo))
                    throw new Exception("Error!");

                await Shell.Current.GoToAsync($"..?Name={Name}&Author={Author}&Pubhouse={PubHouse}&Seria={Seria}&PriceFrom={PriceFrom}&PriceTo={PriceTo}&Search={true}");
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Ошибка!", "Некорректные значения в полях цен", "Ok");
            }
        }
    }
}
