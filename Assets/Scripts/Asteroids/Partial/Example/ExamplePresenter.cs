using System.Collections.Generic;
using Plugins.DI;
using UnityEngine;

namespace Asteroids.Partial.Example
{
    public class ExamplePresenter : MonoBehaviour
    {
        private void Start()
        {
            var container = new Container();
            
            var sceneInstaller = new SceneInstaller();
            sceneInstaller.Install(container);

            var installers = new List<IInstaller>
            {
                new BasicInstaller()
            };
            
            var multiInstaller = new MultiInstaller(installers);
            multiInstaller.Install(container);
            
            // var service = container.Resolve<IService>();
            // service.SomeMethod();
            
            var consumer = container.Resolve<IConsumer>();
            consumer.DoSomething();
        }
    }
}