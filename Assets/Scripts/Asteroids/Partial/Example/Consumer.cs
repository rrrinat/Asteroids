using Plugins.DI;
using UnityEngine;

namespace Asteroids.Partial.Example
{
    public class Consumer : IConsumer
    {
        private readonly IService service;
        private readonly Camera camera;

        public Consumer([Inject] IService service, [Inject] Camera camera)
        {
            this.service = service;
            this.camera = camera;
        }

        public void DoSomething()
        {
            service.SomeMethod();
            
            var cameraPosition = camera.GetComponent<Transform>().position;
            Debug.Log($"Camera position: {cameraPosition}");
        }
    }
}