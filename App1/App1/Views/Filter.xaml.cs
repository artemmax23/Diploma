using App1.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;
using System.Linq;

namespace App1.Views
{
    public partial class Filter : ContentPage
    {
        public Filter()
        {
            InitializeComponent();
            BindingContext = new FilterViewModel();
        }

        public void PriceChange(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            entry.TextChanged -= PriceChange;
            if (entry.Text.Contains(","))
                if ((entry.Text.Substring(entry.Text.IndexOf(',')).Length > 3) || entry.Text.Count(c => c == ',') > 1)
                {
                    entry.Text = e.OldTextValue;
                }
            entry.TextChanged += PriceChange;
        }
    }
}