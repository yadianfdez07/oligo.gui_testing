using oligo.ui.c_sharp_api_text_viewer.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using oligo.domain.infrastructure;
using oligo.module.c_sharp_api_text_viewer;

namespace oligo.ui.c_sharp_api_text_viewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiTextViewer, ApiTextViewerBase>("TextViewerBase");
            containerRegistry.Register<IApiTextViewer, ConstantTextViewer>("ConstantTextViewer");
            containerRegistry.Register<IApiTextViewer, DllImportTextViewer>("DllImportTextViewer");
            containerRegistry.Register<IApiTextViewer, StructTextViewer>("StructTextViewer");
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule(typeof(c_sharp_api_text_viewerModule));
        }
    }
}
