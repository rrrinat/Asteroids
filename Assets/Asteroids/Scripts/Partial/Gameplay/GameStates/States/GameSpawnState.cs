using Asteroids.Partial.Gameplay.Entities;
using Plugins.DI;
using UnityEngine;

namespace Asteroids.Partial.Gameplay.GameStates.States
{
    public class GameSpawnState : GameState
    {
        // private SpaceshipConfig spaceshipConfig;
        //
        // [Inject]
        // public void Construct(SpaceshipConfig spaceshipConfig)
        // {
        //     this.spaceshipConfig = spaceshipConfig;
        // }
        
        private IUnit spaceship;
        
        [Inject]
        public void Construct(IUnit spaceship)
        {
            this.spaceship = spaceship;
        }
        
        public GameSpawnState(GameStateMachine gameStateMachine) : base(gameStateMachine)
        {
        }

        public override void Enter()
        {
            Debug.Log($"GameSpawnState.Enter()");

            //var spaceshipConfig = container.Resolve<SpaceshipConfig>();
            //Debug.Log($"SpaceshipConfig ({spaceshipConfig.MovementSpeed})");
            spaceship.Initialize();
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}