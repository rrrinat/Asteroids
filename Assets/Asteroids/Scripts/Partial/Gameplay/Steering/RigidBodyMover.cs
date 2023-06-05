using UnityEngine;

namespace Asteroids.Partial.Gameplay.Steering
{
    public class RigidBodyMover : IMover
    {
        private Rigidbody rigidBody;

        public RigidBodyMover(Rigidbody rigidBody)
        {
            this.rigidBody = rigidBody;
        }

        public void Move(Vector3 velocity, float deltaTime)
        {
            if (!rigidBody.isKinematic)
            {
                rigidBody.velocity = rigidBody.angularVelocity = Vector3.zero;
            }

            rigidBody.MovePosition(rigidBody.position + (velocity * deltaTime));
        }

        public void Rotate(Quaternion targetRotation, float angularSpeed, float deltaTime)
        {
            var orientation = Quaternion.RotateTowards(rigidBody.rotation, targetRotation, angularSpeed * Mathf.Rad2Deg * deltaTime);
            rigidBody.MoveRotation(orientation);
        }

        public void Stop()
        {
            if (!rigidBody.isKinematic)
            {
                rigidBody.velocity = Vector3.zero;
                rigidBody.Sleep();
            }
        }
    }
}
