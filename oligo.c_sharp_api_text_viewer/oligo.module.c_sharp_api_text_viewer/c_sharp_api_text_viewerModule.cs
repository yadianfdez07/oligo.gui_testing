using oligo.module.c_sharp_api_text_viewer.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace oligo.module.c_sharp_api_text_viewer
{
    public class c_sharp_api_text_viewerModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}