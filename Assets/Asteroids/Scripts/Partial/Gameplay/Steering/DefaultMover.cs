using UnityEngine;

namespace Asteroids.Partial.Gameplay.Steering
{
    public class DefaultMover : IMover
    {
        private Transform transform;

        public DefaultMover(Transform transform)
        {
            this.transform = transform;
        }

        public void Move(Vector3 velocity, float deltaTime)
        {
            transform.position = transform.position + (velocity * deltaTime);
        }

        public void Rotate(Quaternion targetRotation, float angularSpeed, float deltaTime)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angularSpeed * Mathf.Rad2Deg * deltaTime);
        }

        public void Stop()
        {
           
        }
    }
}

