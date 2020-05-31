using HotelBeilaStockageApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelBeilaStockageApp.Interfaces.Services
{
    public interface IUserDataService
    {
        Task<User> GetUserByNameAsync(string name);
    }
}
