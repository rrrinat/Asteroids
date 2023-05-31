using Plugins.DI;
using UnityEngine;

namespace Asteroids.Partial.Example
{
    public class SceneObjectsInstaller : MonoInstaller
    {
        [SerializeField] private Camera mainCamera;
        public override void Install(Container container)
        {
            container.RegisterInstace<Camera>(mainCamera);
        }
    }
}
