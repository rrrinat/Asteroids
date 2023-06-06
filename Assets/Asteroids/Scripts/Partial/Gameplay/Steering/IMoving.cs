using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Partial.Gameplay.Steering
{
    public interface IMoving
    {
        void ForwardStarted(InputAction.CallbackContext context);
        void ForwardCanceled(InputAction.CallbackContext context);
        void RotationPerformed(InputAction.CallbackContext context);
        void RotationCanceled(InputAction.CallbackContext context);
        
        
        void Rotate(Transform transform);
        void Move(Transform transform);
    }
}