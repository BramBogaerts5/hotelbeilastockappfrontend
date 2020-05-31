using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBeilaStockageApp.Interfaces.Services
{
    public interface IDependencyResolver
    {
        object Resolve(Type typeName);
        T Resolve<T>();
    }
}
