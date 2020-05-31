using HotelBeilaStockageApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelBeilaStockageApp.Interfaces.Services
{
    public interface IItemDataService
    {
        Task<IList<Item>> GetItemByAreaAsync(string area);
        Task<IList<Item>> GetAllItemsAsync();
    }
}
