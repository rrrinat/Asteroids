using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Plugins.DI
{
    public class Container
    {
        private Dictionary<Type, Type> dependencyMap;

        public Container()
        {
            dependencyMap = new Dictionary<Type, Type>();
        }

        public void Register<TInterface, TImplementation>()
        {
            dependencyMap[typeof(TInterface)] = typeof(TImplementation);
        }

        public TInterface Resolve<TInterface>()
        {
            Type implementationType = dependencyMap[typeof(TInterface)];
            var instance = CreateInstance(implementationType);
        
            return (TInterface)instance;
        }
        
        private object Resolve(Type type)
        {
            Type implementationType = dependencyMap[type];
            var instance = Activator.CreateInstance(implementationType);

            return instance;
        }

        private object CreateInstance(Type type)
        {
            ConstructorInfo constructor = type.GetConstructors().FirstOrDefault();

            if (constructor != null)
            {
                var parameters = constructor.GetParameters();
                var parameterValues = new List<object>();

                foreach (var parameter in parameters)
                {
                    var injectAttribute = parameter.GetCustomAttribute<InjectAttribute>();
                    if (injectAttribute != null)
                    {
                        var dependencyType = parameter.ParameterType;
                        var dependencyInstance = Resolve(dependencyType);
                        parameterValues.Add(dependencyInstance);
                    }
                }

                return constructor.Invoke(parameterValues.ToArray());
            }

            return Activator.CreateInstance(type);
        }
    }
}