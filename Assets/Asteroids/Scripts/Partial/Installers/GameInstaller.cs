using Asteroids.Partial.Gameplay.InputProcessor;
using Plugins.DI;

namespace Asteroids.Partial.Installers
{
    public class GameInstaller : DefaultInstaller
    {
        public override void Install(DIContainer container)
        {
            // container.Register<IService, Service>();
            // container.Register<IConsumer, Consumer>();
            
            container.RegisterInstance<DefaultInputController>(new DefaultInputController());
        }
    }
}