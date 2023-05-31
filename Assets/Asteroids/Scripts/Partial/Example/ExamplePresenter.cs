using System.Collections.Generic;
using Asteroids.Partial.Installers;
using Plugins.DI;
using UnityEngine;

namespace Asteroids.Partial.Example
{
    public class ExamplePresenter : MonoBehaviour
    {
        private void Start()
        {
            var container = new DIContainer();
            
            var sceneInstaller = new SceneInstaller();
            sceneInstaller.Install(container);

            // var installers = new List<IInstaller>
            // {
            //     new GUIInstaller(),
            //     new BasicInstaller()
            // };
            //
            // var multiInstaller = new MultiInstaller(installers);
            // multiInstaller.Install(container);
            
            
            var guiInstaller = new GUIInstaller();
            guiInstaller.Install(container);
            
            var basicInstaller = new BasicInstaller();
            basicInstaller.Install(container);
            
            // var service = container.Resolve<IService>();
            // service.SomeMethod();
            
            var consumer = container.Resolve<IConsumer>();
            consumer.DoSomething();
        }
    }
}