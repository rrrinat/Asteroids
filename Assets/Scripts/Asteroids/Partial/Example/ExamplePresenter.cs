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

            var service = container.Resolve<IService>();
            service.SomeMethod();
        }
    }
}