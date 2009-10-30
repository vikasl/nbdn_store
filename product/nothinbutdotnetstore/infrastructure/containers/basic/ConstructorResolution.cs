using System;
using System.Linq;
using System.Reflection;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public interface ConstructorResolution    {
        ConstructorInfo pick_constructor_for(Type type);
    }
    class DefaultConstructorResolution : ConstructorResolution
    {
        public ConstructorInfo pick_constructor_for(Type type)
        {
            var constructors1 = type.GetConstructors();
            var constructors = constructors1.OrderByDescending(
                info => info.GetParameters().Count());

            return constructors.Count() > 0 ? constructors.First() : null;
        }
    }
}