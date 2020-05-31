using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBeilaStockageApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Area { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Supplier { get; set; }
    }
}
