using System;
using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.tasks.startup
{
    public interface ContainerCoreService
    {
        void register_an_activator_for<ContractType>(Func<object> activator);
        void register<ContractType,Implementation>();
        void register<Implementation>();
        Dependency resolve<Dependency>();
        Container container { get; }
    }

    public class DefaultContainerCoreService : ContainerCoreService {

        private IDictionary<Type, InstanceActivator> activators;
        public Container container { get; private set; }

        public DefaultContainerCoreService()
        {
            this.activators = activators = new Dictionary<Type, InstanceActivator>();
            ActivatorRegistry registry = new DefaultActivatorRegistry(activators);
            container = new DefaultContainer(registry);
        }

        public void register<ContractType, Implementation>()
        {
            activators.Add(typeof(ContractType),
                new AutoWiringInstanceActivator(new DefaultConstructorResolution(), typeof(Implementation)));
        }

        public void register<Implementation>()
        {
            activators.Add(typeof(Implementation),
                new AutoWiringInstanceActivator(new DefaultConstructorResolution(), typeof(Implementation)));
        }

        public void register_an_activator_for<ContractType>(Func<object> activator)
        {
            activators.Add(typeof (ContractType), new FunctionalInstanceActivator(activator));        
        }

        public Dependency resolve<Dependency>()
        {
            return container.instance_of<Dependency>();
        }
    }
}