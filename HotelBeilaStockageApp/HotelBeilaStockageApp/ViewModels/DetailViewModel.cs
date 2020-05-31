using HotelBeilaStockageApp.Models;
using HotelBeilaStockageApp.ViewModels.Base;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using HotelBeilaStockageApp.Interfaces.Services;
using HotelBeilaStockageApp.Views;

namespace HotelBeilaStockageApp.ViewModels
{
    public class DetailViewModel : ViewModelBase
    {
        Item currentItem;
        private string name = "Unknown";
        private string area = "Unknown";
        private string supplier = "Unknown";
        private string description = "Unknown";
        private string message;
        private int amount = 0;
        List<string> recipients = new List<string>();
        public DetailViewModel()
        {
            recipients.Add("bram.bogaerts5@gmail.com");
            MessagingCenter.Subscribe<SelectProductViewModel, Item>(this, "product", (sender,arg) =>
            {
                currentItem = arg;
                Name = currentItem.Name;
                Area = currentItem.Area;
                Supplier = currentItem.Supplier;
                Description = currentItem.Description;
                Amount = currentItem.Amount;
            });
        }

        public ICommand SendCommand => new Command(OnSendAsync);

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
         
        public string Area
        {
            get { return area; }
            set {
                area = value;
                OnPropertyChanged();
            }
        }

        public string Supplier
        {
            get { return supplier; }
            set
            {
                supplier = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged();
            }
        }

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged();
            }
        }

        private async void OnSendAsync()
        {
            string body = "We're almost out of " + currentItem.Name + ". There are only " + Amount + " left. You can order them from " + currentItem.Supplier + ".";
            await SendEmail("Hotel Beila To Order", body, recipients);
            await App.Current.MainPage.Navigation.PushAsync(new SelectAreaPage());
        }

        public async Task SendEmail(string subject, string body, List<string> recipients)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = recipients
                };
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {

            }
            catch (Exception ex)
            {
                
            }
        }

    }
}
