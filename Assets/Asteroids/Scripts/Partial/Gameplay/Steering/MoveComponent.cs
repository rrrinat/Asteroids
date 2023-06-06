using Asteroids.Partial.Gameplay.Steering.Configs;
using Plugins.DI;
using UnityEngine;

namespace Asteroids.Partial.Gameplay.Steering
{
    public class MoveComponent
    {
        private Transform transform;
        
        private MovementConfig movementConfig;

        [Inject]
        public void Construct(MovementConfig movementConfig)
        {
            this.movementConfig = movementConfig;
        }

        public MoveComponent()
        {

            // var defaultInput = new DefaultInput();
            // defaultInput.Enable();
            //
            // defaultInput.Spaceship.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
        }

        public void Update()
        {
            
        }
        
        private void Move(Vector2 direction)
        {

        }
    }
}