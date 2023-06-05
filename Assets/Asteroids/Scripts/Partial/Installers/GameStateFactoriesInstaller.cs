using Asteroids.Partial.Gameplay.GameStates;
using Plugins.DI;

namespace Asteroids.Partial.Installers
{
    public class GameStateFactoriesInstaller : DefaultInstaller
    {
        public override void Install(DIContainer container)
        {
            container.Register<IGameStateMachine, GameStateMachine>();
        }
    }
}