using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Plugins.DI
{
    public class Container
    {
        private Dictionary<Type, Type> dependencyMap;
        private Dictionary<Type, object> instancesMap;

        public Container()
        {
            dependencyMap = new Dictionary<Type, Type>();
            instancesMap = new Dictionary<Type, object>();
        }

        public void Register<TInterface, TImplementation>()
        {
            dependencyMap[typeof(TInterface)] = typeof(TImplementation);
        }

        public T Resolve<T>()
        {
            if (dependencyMap.TryGetValue(typeof(T), out var implementationType))
            {
                var instance = CreateInstance(implementationType);
                
                return (T)instance;
            }
            else if (instancesMap.TryGetValue(typeof(T), out var instance))
            {
                return (T)instance;
            }
            else
            {
                throw new InvalidOperationException($"Type {typeof(T).Name} is not registered in the container.");
            }
        }
        
        private object Resolve(Type type)
        {
            if (dependencyMap.TryGetValue(type, out var implementationType))
            {
                var instance = CreateInstance(implementationType);
                
                return instance;
            }
            else if (instancesMap.TryGetValue(type, out var instance))
            {
                return instance;
            }
            else
            {
                throw new InvalidOperationException($"Type {type.Name} is not registered in the container.");
            }
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
        
        public void RegisterInstace<T>(object instance)
        {
            Type type = typeof(T);
            instancesMap[type] = instance;
        }
    }
}