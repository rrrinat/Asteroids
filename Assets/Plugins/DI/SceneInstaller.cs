using UnityEngine;

namespace Plugins.DI
{
    public class SceneInstaller
    {
        public void Install(DIContainer diContainer)
        {
            var installers = Object.FindObjectsByType<MonoInstaller>(FindObjectsSortMode.None);
            foreach (var installer in installers)
            {
                installer.Install(diContainer);
            }
        }
    }
}