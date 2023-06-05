using System;
using System.Collections.Generic;
using Asteroids.Partial.Gameplay.GameStates.States;
using Plugins.DI;
using Plugins.StateMachine;

namespace Asteroids.Partial.Gameplay.GameStates
{
    public class GameStateMachine : StateMachine, IGameStateMachine
    {
        private readonly Dictionary<Type, GameState> gameStates = new ();

        private DIContainer container;
        
        [Inject]
        public void Construct(DIContainer container)
        {
            this.container = container;
        }
        
        public override void Initialize()
        {
            var idleState = new GameIdleState(this);
            
            AddState<GameIdleState>(idleState);
            AddState<GameSpawnState>(new GameSpawnState(this));

            base.Initialize(idleState);
        }
        
        private void AddState<T>(T gameState) where T : GameState
        {
            gameStates[typeof(T)] = gameState;
            
            container.RegisterInstance<T>(gameState);
        }

        public void SetState<T>() where T : GameState
        {
            if (gameStates.TryGetValue(typeof(T), out var state))
            {
                SetState(state);
            }
        }
    }
}
