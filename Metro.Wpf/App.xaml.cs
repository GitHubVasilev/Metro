using DryIoc.Microsoft.DependencyInjection.Extension;
using Metro.Wpf.View;
using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;
using Metro.Services.Infrastructure;
using AutoMapper;
using Metro.Wpf.Infrastricture.Mapper;
using Prism.Modularity;
using Metro.Wpf.Modules;
using Prism.Mvvm;
using Metro.Wpf.View.Controls;
using Microsoft.Extensions.DependencyInjection;
using Metro.Wpf.ViewModels;

namespace Metro.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <inheritdoc />
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(conf =>
            {
                conf.AddProfile<StationMapperConfiguration>();
                conf.AddProfile<BranchMapperConfiguration>();
            });
            mapperConfiguration.AssertConfigurationIsValid();
            containerRegistry.GetContainer().RegisterServices(services =>
            {
                services.AddServices();
                services.AddSingleton(mapperConfiguration.CreateMapper());
            });


            #region Dialogs

            #endregion
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.Register<StationsControlRegion, StationsViewModel>();
            ViewModelLocationProvider.Register<StationsPathControlRegion, StationsPathViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<StationsModule>();
        }

        /// <inheritdoc />
        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }
    }
}
