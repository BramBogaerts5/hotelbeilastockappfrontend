using HotelBeilaStockageApp.Constants;
using HotelBeilaStockageApp.Interfaces.Repositories;
using HotelBeilaStockageApp.Interfaces.Services;
using HotelBeilaStockageApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelBeilaStockageApp.Services.Data
{
    public class UserDataService : IUserDataService
    {
        private readonly IGenericRepository _repository;

        public UserDataService(IGenericRepository repository)
        {
            _repository = repository;
        }

        public async Task<User>GetUserByNameAsync(string name)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.UserByNameEndpoint(name)
            };
            User user = await _repository.GetAsync<User>(builder.ToString());
            return user;
        }
    }
}
