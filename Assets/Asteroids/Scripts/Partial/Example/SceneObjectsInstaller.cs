using Plugins.DI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Asteroids.Partial.Example
{
    public class SceneObjectsInstaller : MonoInstaller
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Canvas mainCanvas;
        [SerializeField] private EventSystem eventSystem;
        
        public override void Install(DIContainer container)
        {
            container.RegisterInstance<Camera>(mainCamera);
            container.RegisterInstance<Canvas>(mainCanvas);
            container.RegisterInstance<EventSystem>(eventSystem);
        }
    }
}
