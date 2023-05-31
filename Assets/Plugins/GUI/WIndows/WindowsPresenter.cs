using System.Collections.Generic;
using System.Threading.Tasks;
using Plugins.DI;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Plugins.GUI.WIndows
{
    public class WindowsPresenter : IWindowsPresenter
    {
        private IWindowsContainer windowsContainer;
        private DIContainer diContainer;

        private Dictionary<int, AsyncOperationHandle<GameObject>> handles;

        public WindowsPresenter()
        {
            handles = new Dictionary<int, AsyncOperationHandle<GameObject>>();
        }
        
        [Inject]
        public void Construct(DIContainer container, IWindowsContainer windowsContainer)
        {
            this.diContainer = container;
            this.windowsContainer = windowsContainer;
        }
        
        public async Task<T> CreateAsync<T>() where T : WindowBase
        {
            var window = await CreateInternal<T>();

            windowsContainer.Add(window);

            return window;
        }
        
        private async Task<T> CreateInternal<T>() where T : WindowBase
        {
            var type = typeof(T);
            var hashCode = type.GetHashCode();
        
            if (windowsContainer.TryGetWindow(hashCode, out var windowBase))
            {
                return windowBase as T;
            }
            
            var handle = Addressables.LoadAssetAsync<GameObject>(type.Name);
            handles.Add(hashCode, handle);
            
            await handle.Task;

            var instance = GameObject.Instantiate(handle.Result);
            
            var window = instance.GetComponent<WindowBase>() as T;

            if (window == null)
            {
                Debug.LogError($"Couldn't cast {window} as {type.Name}");
                
                return null;
            }

            diContainer.RegisterInstance<T>(window);

            return window;
        }       
        
        public void Close(WindowBase window)
        {
            windowsContainer.Remove(window);

            Object.Destroy(window.gameObject);
            if (handles.TryGetValue(window.GetType().GetHashCode(), out var handle))
            {
                Addressables.Release(handle);
                
                handles.Remove(window.GetType().GetHashCode());
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
