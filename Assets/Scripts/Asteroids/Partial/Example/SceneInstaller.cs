using Plugins.DI;
using UnityEngine;

namespace Asteroids.Partial.Example
{
    public class SceneInstaller
    {
        public void Install(Container container)
        {
            var installers = Object.FindObjectsByType<MonoInstaller>(FindObjectsSortMode.None);
            foreach (var installer in installers)
            {
                installer.Install(container);
            }
        }
    }
}