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
    public class ItemDataService : IItemDataService
    {
        private readonly IGenericRepository _repository;

        public ItemDataService(IGenericRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<Item>>GetItemByAreaAsync(string area)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.ItemByAreaEndpoint(area)
            };
            var items = await _repository.GetAsync<IList<Item>>(builder.ToString());
            return items;
        }

        public async Task<IList<Item>>GetAllItemsAsync()
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.AllItemsEndpoint()
            };
            var items = await _repository.GetAsync<IList<Item>>(builder.ToString());
            return items;
        }
    }
}
