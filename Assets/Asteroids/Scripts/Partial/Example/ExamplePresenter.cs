using System;
using System.Collections.Generic;
using Asteroids.Partial.Installers;
using Plugins.DI;
using UnityEngine;

namespace Asteroids.Partial.Example
{
    public class ExamplePresenter : MonoBehaviour
    {
        private IConsumer consumer;
        
        private void Start()
        {
            var container = new DIContainer();
            
            container.RegisterInstance<DIContainer>(container);
            
            var sceneInstaller = new SceneInstaller();
            sceneInstaller.Install(container);

            var installers = new List<IInstaller>
            {
                new GUIInstaller(),
                new BasicInstaller()
            };
            
            var multiInstaller = new MultiInstaller(installers);
            multiInstaller.Install(container);
            
            
            // var guiInstaller = new GUIInstaller();
            // guiInstaller.Install(container);
            //
            // var basicInstaller = new BasicInstaller();
            // basicInstaller.Install(container);
            
            // var service = container.Resolve<IService>();
            // service.SomeMethod();
            
            consumer = container.Resolve<IConsumer>();
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                consumer.DoSomething();
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                consumer.Close();
            }
            
        }
    }
}