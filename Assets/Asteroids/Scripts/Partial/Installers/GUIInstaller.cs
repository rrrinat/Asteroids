using Plugins.DI;
using Plugins.GUI.WIndows;

namespace Asteroids.Partial.Installers
{
    public class GUIInstaller : DefaultInstaller
    {
        public override void Install(DIContainer container)
        {
            container.Register<IWindowsContainer, WindowsContainer>();
            container.Register<IWindowsPresenter, WindowsPresenter>();
        }
    }
}