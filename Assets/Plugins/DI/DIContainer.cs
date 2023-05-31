using System;
using System.Collections.Generic;
using System.Linq;

namespace Plugins.DI
{
    public class DIContainer
    {
        private Dictionary<Type, Type> dependencyMap;
        private Dictionary<Type, object> instancesMap;

        public DIContainer()
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
            var instance = Activator.CreateInstance(type);
            InjectDependencies(instance);
            return instance;
        }
        
        private void InjectDependencies(object obj)
        {
            var type = obj.GetType();
            var methods = type.GetMethods().Where(m => m.GetCustomAttributes(typeof(InjectAttribute), false).Length > 0);
            foreach (var method in methods)
            {
                var parameters = method.GetParameters();
                var dependencies = parameters.Select(p => Resolve(p.ParameterType)).ToArray();
                method.Invoke(obj, dependencies);
            }
        }
        
        public void RegisterInstance<T>(object instance)
        {
            Type type = typeof(T);
            instancesMap[type] = instance;
        }
    }
}