using Plugins.DI;
namespace Asteroids.Partial.Example
{
    public class BasicInstaller : DefaultInstaller
    {
        public override void Install(Container container)
        {
            container.Register<IService, Service>();
            container.Register<IConsumer, Consumer>();
        }
    }
}