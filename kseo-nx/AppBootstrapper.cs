using System;
using System.Collections.Generic;
using Caliburn.Micro;
using kseo_nx.ViewModels;
using Caliburn.Micro.Extras;

namespace kseo_nx
{
    public class AppBootstrapper :BootstrapperBase
    {
        private SimpleContainer _container;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container=new SimpleContainer();
            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IMessageService, MessageService>();
            _container.Singleton<IEventAggregator, EventAggregator>();
            _container.PerRequest<IShell, ShellViewModel>();
            

        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = _container.GetInstance(service, key);
            if (instance != null)
                return instance;

            throw new Exception("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<IShell>();
        }
    }
}
