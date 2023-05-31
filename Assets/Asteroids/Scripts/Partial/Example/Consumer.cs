using Plugins.DI;
using Plugins.GUI.WIndows;
using UnityEngine;

namespace Asteroids.Partial.Example
{
    public class Consumer : IConsumer
    {
        private IService service;
        private Camera camera;
        private IWindowsPresenter windowsPresenter;
        
        [Inject]
        public void Construct(IService service, Camera camera, IWindowsPresenter windowsPresenter)
        {
            this.service = service;
            this.camera = camera;
            this.windowsPresenter = windowsPresenter;
        }

        public void DoSomething()
        {
            service.SomeMethod();
            
            var cameraPosition = camera.GetComponent<Transform>().position;
            Debug.Log($"Camera position: {cameraPosition}");

            ShowExampleWindow();
        }

        private async void ShowExampleWindow()
        {
            await windowsPresenter.ShowAsync<ExampleWindow>();
        }
    }
}