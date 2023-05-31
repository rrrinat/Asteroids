using Plugins.DI;
namespace Asteroids.Partial.Example
{
    public class BasicInstaller : MonoInstaller
    {
        public override void Install(Container container)
        {
            container.Register<IService, Service>();
        }
    }
}