using System.Threading.Tasks;

namespace Plugins.GUI.WIndows
{
    public interface IWindowsPresenter
    {
        Task<T> CreateAsync<T>() where T : WindowBase;
        void Close(WindowBase window);
        void TryClose<T>() where T : WindowBase;
    }
}