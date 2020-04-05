using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;

namespace EHI.WebApp.App_Start {
    public class NinjectDependencyResolver : System.Web.Mvc.IDependencyResolver {
        private readonly IKernel _kernel;
        public NinjectDependencyResolver() {
            _kernel = new StandardKernel();
            _kernel.Unbind<ModelValidatorProvider>();
            AddBindings();
        }
        public object GetService(Type serviceType) {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings() {
            _kernel.Bind<Data.IEHIDataRepository>().To<Data.EHIDataRepository>();
        }
    }
}