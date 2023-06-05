using System.Collections.Generic;
using Asteroids.Partial.Example;
using Asteroids.Partial.Installers;
using Plugins.DI;

namespace Asteroids.Partial.GameServices
{
    public class InstallService
    {
        public void Install(DIContainer container)
        {
            var sceneInstaller = new SceneInstaller();
            sceneInstaller.Install(container);

            var installers = new List<IInstaller>
            {
                new BasicInstaller(),
                new GUIInstaller(),
                new GameStateFactoriesInstaller()
            };
            
            var multiInstaller = new MultiInstaller(installers);
            multiInstaller.Install(container);
        }
    }
}