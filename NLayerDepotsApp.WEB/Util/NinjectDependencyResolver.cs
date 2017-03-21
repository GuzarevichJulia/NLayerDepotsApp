using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLayerDepotsApp.BLL.Services;
using Ninject;
using NLayerDepotsApp.BLL.Interfaces;
using System.Web.Mvc;

namespace NLayerDepotsApp.WEB.Util
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
            kernel.Bind<IService>().To<DrugUnitService>();
        }
    }
}