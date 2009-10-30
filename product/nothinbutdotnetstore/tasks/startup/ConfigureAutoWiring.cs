using System;
using System.Collections.Generic;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.infrastructure;
using nothinbutdotnetstore.web.infrastructure.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureAutoWiring : StartupCommand
    {
        private readonly ContainerCoreService core_service;

        public ConfigureAutoWiring(ContainerCoreService core_service)
        {
            this.core_service = core_service;
        }

        public void run()
        {
            
            var route_table = new DefaultRouteTable();
            core_service.register_an_activator_for<RouteTable>(() => route_table);
            core_service.register_an_activator_for<IEnumerable<Command>>(() => route_table);

            core_service.register<FrontControllerRequestFactory, StubRequestFactory>();
            core_service.register<FrontController, DefaultFrontController>();

            core_service.register<CommandRegistry, DefaultCommandRegistry>();

            core_service.register<MapperRegistry, StubMapperRegistry>();

            core_service.register<ViewMainDepartments>();
            core_service.register<ResponseEngine, DefaultResponseEngine>();
            core_service.register<ViewFactory, DefaultViewFactory>();
            core_service.register<ViewPathRegistry, StubViewPathRegistry>();

            core_service.register<CatalogTasks, StubCatalogTasks>();
           
        }
    }
}