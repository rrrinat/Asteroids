namespace Plugins.GUI.WIndows
{
    public interface IWindowsContainer
    {
        void Add(WindowBase window);
        void Remove(WindowBase window);
        bool TryGetWindow<T>(out T window) where T : WindowBase;
        bool TryGetWindow(int key, out WindowBase windowBase);
        bool Contains<T>() where T : WindowBase;
    }
}