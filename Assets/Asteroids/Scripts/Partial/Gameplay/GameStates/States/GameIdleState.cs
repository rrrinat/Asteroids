using UnityEngine;

namespace Asteroids.Partial.Gameplay.GameStates.States
{
    public class GameIdleState : GameState
    {
        public GameIdleState(GameStateMachine gameStateMachine) : base(gameStateMachine)
        {
        }

        public override void Enter()
        {
            Debug.Log($"GameIdleState.Enter()");

            GameStateMachine.SetState<GameSpawnState>();
            
        }

        public override void Update()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}