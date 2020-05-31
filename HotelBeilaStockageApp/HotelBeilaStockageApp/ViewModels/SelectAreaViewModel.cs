using HotelBeilaStockageApp.ViewModels.Base;
using System.Windows.Input;
using Xamarin.Forms;
using HotelBeilaStockageApp.Views;

namespace HotelBeilaStockageApp.ViewModels
{
    public class SelectAreaViewModel : ViewModelBase
    {
        public ICommand GoToBarCommand => new Command(GoToBarAsync);
        public ICommand GoToBreakfastCommand => new Command(GoToBreakfastAsync);
        public ICommand GoToCleaningCommand => new Command(GoToCleaningAsync);
        public ICommand GoToOtherCommand => new Command(GoToOtherAsync);


        private async void GoToBarAsync()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SelectProductPage());
            MessagingCenter.Send<SelectAreaViewModel, string>(this, "whichArea", "bar");
        }

        private async void GoToBreakfastAsync()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SelectProductPage());
            MessagingCenter.Send<SelectAreaViewModel, string>(this, "whichArea", "breakfast");
        }

        private async void GoToCleaningAsync()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SelectProductPage());
            MessagingCenter.Send<SelectAreaViewModel, string>(this, "whichArea", "cleaning");
        }

        private async void GoToOtherAsync()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SelectProductPage());
            MessagingCenter.Send<SelectAreaViewModel, string>(this, "whichArea", "other");
        }
    }
}
