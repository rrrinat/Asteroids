using System.Collections.Generic;
using Plugins.DI;
using Plugins.GUI.Extensions;
using UnityEngine;

namespace Plugins.GUI.WIndows
{
    public class WindowsContainer : IWindowsContainer
    {
        private Dictionary<int, WindowBase> windows;
        private Transform canvasTransform;
        private RectTransform holder;

        public WindowsContainer()
        {
            windows = new Dictionary<int, WindowBase>();
        }
        
        [Inject] 
        public void Construct(Canvas mainCanvas)
        {
            canvasTransform = mainCanvas.transform;
            
            CreateHolder();
        }

        private void CreateHolder()
        {
            var go = new GameObject("Default")
            {
                layer = LayerMask.NameToLayer("UI")
            }; 
            holder = go.AddComponent<RectTransform>();
            holder.SetParent(canvasTransform);
            holder.StretchToParent();
        }
        
        public void Add(WindowBase window)
        {
            var type = window.GetType();
            var hashCode = type.GetHashCode();

            if (windows.ContainsKey(hashCode))
                return;
            
            window.Initialize();

            window.RectTransform.SetParent(holder);
            window.RectTransform.StretchToParent();

            windows[hashCode] = window;
        }

        public void Remove(WindowBase window)
        {
            windows.Remove(window.GetType().GetHashCode());
        }
        
        public bool TryGetWindow<T>(out T window) where T : WindowBase
        {
            if (TryGetWindow(typeof(T).GetHashCode(), out var windowBase))
            {
                window = (T) windowBase;
                return true;
            }

            window = null;
            return false;
        }

        public bool TryGetWindow(int key, out WindowBase windowBase)
        {
            return windows.TryGetValue(key, out windowBase);
        } 
        
        private bool ContainsKey(int hashCode)
        {
            return windows.ContainsKey(hashCode);
        }

        public bool Contains<T>() where T : WindowBase
        {
            return ContainsKey(typeof(T).GetHashCode());
        }        
    }
}
