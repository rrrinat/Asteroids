using Asteroids.Partial.Gameplay.GameStates.States;

namespace Asteroids.Partial.Gameplay.GameStates
{
    public interface IGameStateMachine
    {
        void Initialize();
        void Update();
        void SetState<T>() where T : GameState;
    }
}