using UnityEngine;

namespace Asteroids.Partial.Gameplay.InputProcessor
{
    public class DefaultInputController
    {
        public DefaultInputController()
        {
            var defaultInput = new DefaultInput();
            defaultInput.Enable();
            
            defaultInput.Spaceship.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
           
        }
        
        
        private void Move(Vector2 direction)
        {
            Debug.Log($"direction {direction}");
        }
    }
}