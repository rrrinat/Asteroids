using Asteroids.Partial.Gameplay.Steering.Configs;
using Plugins.DI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Partial.Gameplay.Steering
{
    public class MoveComponent : IMoving
    {
        private MovementConfig movementConfig;

        //Input
        private float verticalDirection;
        private float horizontalDirection;
        
        private Vector2 moveDirection;
        private Vector3 currentMoveVelocity;

        private float desiredMoveSpeed;
        private float currentMoveSpeed;

        private float currentRotationSpeed;
        private Quaternion targetRotation;
        
        private bool IsMoving => moveDirection != Vector2.zero;
        private bool IsRotating => horizontalDirection != 0f;
        
        private float RotationInertia => (IsRotating) ? movementConfig.RotationAmplification : movementConfig.RotationDamping;
        private float MovementInertia => (IsMoving) ? movementConfig.MovementAmplification : movementConfig.MovementDamping;

        [Inject]
        public void Construct(MovementConfig movementConfig)
        {
            this.movementConfig = movementConfig;
        }

        public void ForwardStarted(InputAction.CallbackContext context)
        {
            verticalDirection = 1f;
        }
        
        public void ForwardCanceled(InputAction.CallbackContext context)
        {
            verticalDirection = 0f;
        }
        
        public void RotationPerformed(InputAction.CallbackContext context)
        {
            horizontalDirection = context.ReadValue<float>();
        }
        
        public void RotationCanceled(InputAction.CallbackContext context)
        {
            horizontalDirection = 0f;
        }
        
        public void Update(Transform transform)
        {
            currentRotationSpeed = Mathf.MoveTowards(currentRotationSpeed, horizontalDirection * movementConfig.RotationSpeed, RotationInertia * Time.deltaTime);
            transform.rotation *= Quaternion.Euler(0f, currentRotationSpeed * Time.deltaTime, 0f);
            
            desiredMoveSpeed = verticalDirection * movementConfig.MovementSpeed;
            currentMoveSpeed = Mathf.Lerp(currentMoveSpeed, desiredMoveSpeed, Time.deltaTime * MovementInertia);
            currentMoveVelocity = transform.forward * currentMoveSpeed;

            transform.position = transform.position + (currentMoveVelocity * Time.deltaTime);
        }
    }
}