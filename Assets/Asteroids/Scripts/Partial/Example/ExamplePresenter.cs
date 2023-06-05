using System;
using System.Collections.Generic;
using Asteroids.Partial.Gameplay.GameStates;
using Asteroids.Partial.Installers;
using Plugins.DI;
using UnityEngine;

namespace Asteroids.Partial.Example
{
    public class ExamplePresenter : MonoBehaviour
    {
        private IConsumer consumer;
        private IGameStateMachine gameStateMachine;
        
        private void Start()
        {
            var container = new DIContainer();
            container.RegisterInstance<DIContainer>(container);
            
            // var sceneInstaller = new SceneInstaller();
            // sceneInstaller.Install(container);
            //
            // var installers = new List<IInstaller>
            // {
            //     new GUIInstaller(),
            //     new GameStateFactoriesInstaller(),
            //     new BasicInstaller()
            // };
            //
            // var multiInstaller = new MultiInstaller(installers);
            // multiInstaller.Install(container);
            
            consumer = container.Resolve<IConsumer>();
            
            gameStateMachine = container.Resolve<IGameStateMachine>();
            
            gameStateMachine.Initialize();
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
            
            gameStateMachine.Update();
        }
    }
}