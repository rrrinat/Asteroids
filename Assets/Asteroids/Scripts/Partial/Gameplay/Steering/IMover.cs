using UnityEngine;

namespace Asteroids.Partial.Gameplay.Steering
{
    public interface IMover
    {
        void Move(Vector3 velocity, float deltaTime);
        void Rotate(Quaternion targetRotation, float angularSpeed, float deltaTime);
        void Stop();
    }
}
