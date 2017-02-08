using HistoricPhotoStore.Abstract;
using HistoricPhotoStore.Data;
using HistoricPhotoStore.Presentation.Helpers;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace HistoricPhotoStore.Presentation.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<HistoricPhotoStoreService>().To<DefaultHistoricPhotoStoreService>();
            kernel.Bind<PathHelper>().To<WebServerPathHelper>();
            kernel.Bind<DataStorage>().To<EntityFrameworkDataStorage>().WithConstructorArgument(
                ConfigurationManager.ConnectionStrings["HistoricPhotoStoreContext"].ConnectionString);

            kernel.Bind<ImageStorage>().To<FileBasedImageStorage>();
        }
    }
}