using Asteroids.Partial.Gameplay.Entities;
using Asteroids.Partial.Gameplay.Steering;
using Plugins.DI;

namespace Asteroids.Partial.Installers
{
    public class GameInstaller : DefaultInstaller
    {
        public override void Install(DIContainer container)
        {
            container.Register<IMoving, MoveComponent>();
            container.Register<IUnit, Spaceship>();
        }
    }
}