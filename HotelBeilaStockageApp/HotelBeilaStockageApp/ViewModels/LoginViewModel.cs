using HotelBeilaStockageApp.Constants;
using HotelBeilaStockageApp.Container;
using HotelBeilaStockageApp.Interfaces.Services;
using HotelBeilaStockageApp.Models;
using HotelBeilaStockageApp.ViewModels.Base;
using HotelBeilaStockageApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HotelBeilaStockageApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _userName;
        private string _password;
        private string _message;
        private readonly IUserDataService _userDataService;

        public LoginViewModel()
        {
            _userDataService = (IUserDataService)AppContainer.Instance.Resolve(typeof(IUserDataService));
        }

        public ICommand LoginCommand => new Command(OnLoginAsync);

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        private async void OnLoginAsync()
        {
            Message = "";

            if(_userName == null || _password == null)
            {
                Message = "Please fill in a user and a password";
            }
            else
            {
                User user = await _userDataService.GetUserByNameAsync(_userName);

                if (user == null)
                {
                    Message = "This user doesn't exist";
                }
                else if (user.Password != _password)
                {
                    Message = "This password is not correct";
                }
                else
                {
                    MessagingCenter.Send(this, MessagingConstants.PassUser, user);
                    await App.Current.MainPage.Navigation.PushAsync(new SelectAreaPage());
                }
            }
        }

    }
}
