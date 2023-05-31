using System.Threading.Tasks;
using Plugins.DI;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Plugins.GUI.WIndows
{
    public class WindowsPresenter : IWindowsPresenter
    {
        private IWindowsContainer windowsContainer;
        private DIContainer diContainer;

        [Inject]
        public void Construct(IWindowsContainer windowsContainer)
        {
            this.windowsContainer = windowsContainer;
        }
        
        public async Task<T> ShowAsync<T>() where T : WindowBase
        {
            var window = await ShowInternal<T>();

            windowsContainer.Add(window);
            window.Show();

            return window;
        }
        
        private async Task<T> ShowInternal<T>() where T : WindowBase
        {
            var type = typeof(T);
            var hashCode = type.GetHashCode();
        
            if (windowsContainer.TryGetWindow(hashCode, out var windowBase))
            {
                return windowBase as T;
            }
            
            var handle = Addressables.InstantiateAsync(type.Name);
            await handle.Task;
            var instance = handle.Result;
            
            var window = instance.GetComponent<WindowBase>() as T;

            if (window == null)
            {
                Debug.LogError($"Couldn't cast {window} as {type.Name}");
                
                return null;
            }

            //container.InjectGameObject(instance);

            return window;
        }       
        
        public void Close(WindowBase window)
        {
            windowsContainer.Remove(window);
            
            if (!Addressables.ReleaseInstance(window.gameObject))
            {
                GameObject.Destroy(window.gameObject);
            }
        }
        
        public void TryClose<T>() where T : WindowBase
        {
            if (windowsContainer.TryGetWindow(out T window))
            {
                window.Close();
            }
        }
    }
}
