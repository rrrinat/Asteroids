using Asteroids.Partial.Gameplay.Steering.Configs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Partial.Gameplay.Entities
{
    public class SpaceshipView : MonoBehaviour
    {
        [SerializeField]
        private MovementConfig movementConfig;

        private Vector2 moveDirection;

        private Vector3 currentVelocity;

        private float desiredSpeed;
        private float currentSpeed;

        private float currentRotationSpeed;
        private Quaternion targetRotation;
        
        private float verticalDirection;
        private float horizontalDirection;

        private bool IsMoving => moveDirection != Vector2.zero;
        private bool IsRotating => horizontalDirection != 0f;
        
        private float RotationInertia => (IsRotating) ? movementConfig.RotationAmplification : movementConfig.RotationDamping;
        private float MovementInertia => (IsMoving) ? movementConfig.MovementAmplification : movementConfig.MovementDamping;
        
        private void Start()
        {
            var defaultInput = new DefaultInput();
            defaultInput.Enable();
            
            defaultInput.Spaceship.Forward.started += ForwardStarted;
            defaultInput.Spaceship.Forward.canceled += ForwardCanceled;
            
            defaultInput.Spaceship.Rotation.performed += RotationPerformed;
            defaultInput.Spaceship.Rotation.canceled += RotationCanceled;
        }
        
        private void ForwardStarted(InputAction.CallbackContext context)
        {
            verticalDirection = 1f;
        }
        
        private void ForwardCanceled(InputAction.CallbackContext context)
        {
            verticalDirection = 0f;
        }
        
        private void RotationPerformed(InputAction.CallbackContext context)
        {
            horizontalDirection = context.ReadValue<float>();
        }
        
        private void RotationCanceled(InputAction.CallbackContext context)
        {
            horizontalDirection = 0f;
        }
        
        private void Update()
        {
            currentRotationSpeed = Mathf.MoveTowards(currentRotationSpeed, horizontalDirection * movementConfig.RotationSpeed, RotationInertia * Time.deltaTime);
            transform.rotation *= Quaternion.Euler(0f, currentRotationSpeed * Time.deltaTime, 0f);

            desiredSpeed = verticalDirection * movementConfig.MovementSpeed;
            currentSpeed = Mathf.Lerp(currentSpeed, desiredSpeed, Time.deltaTime * MovementInertia);
            currentVelocity = transform.forward * currentSpeed;

            transform.position = transform.position + (currentVelocity * Time.deltaTime);
        }
    }
}