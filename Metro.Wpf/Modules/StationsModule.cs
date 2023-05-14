using Metro.Wpf.View.Controls;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Metro.Wpf.Modules
{
    internal class StationsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("StationsRegion", typeof(StationsControlRegion));
        }
        
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<StationsPathControlRegion>();
        }
    }
}
