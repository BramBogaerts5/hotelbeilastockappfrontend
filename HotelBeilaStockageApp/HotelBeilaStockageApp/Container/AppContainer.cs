using HotelBeilaStockageApp.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using HotelBeilaStockageApp.ViewModels;
using HotelBeilaStockageApp.Services.Data;
using HotelBeilaStockageApp.Services.General;
using HotelBeilaStockageApp.Repositories;
using HotelBeilaStockageApp.Interfaces.Repositories;

namespace HotelBeilaStockageApp.Container
{
    class AppContainer : IDependencyResolver
    {
        private IContainer _container;
        private static AppContainer _instance;
        public static AppContainer Instance => _instance ?? (_instance = new AppContainer());

        private AppContainer()
        {
            RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //ViewModels
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<SelectAreaViewModel>();
            builder.RegisterType<SelectProductViewModel>();
            builder.RegisterType<DetailViewModel>();

            //Services
            builder.Register(c => Instance).As<IDependencyResolver>();
            builder.RegisterType<UserDataService>().As<IUserDataService>();
            builder.RegisterType<ItemDataService>().As<IItemDataService>();

            //Repository
            builder.RegisterType<GenericRepository>().As<IGenericRepository>();

            _container = builder.Build();
        }

        public object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
