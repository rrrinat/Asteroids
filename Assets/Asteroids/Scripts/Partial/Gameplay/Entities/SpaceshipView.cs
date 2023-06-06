using System;
using UnityEngine;

namespace Asteroids.Partial.Gameplay.Entities
{
    public class SpaceshipView : MonoBehaviour
    {
        private Action<Transform> rotate;
        private Action<Transform> move;

        public void Initialize(Action<Transform> rotate, Action<Transform> move)
        {
            this.rotate = rotate;
            this.move = move;
        }
        
        private void Update()
        {
            rotate?.Invoke(transform);
            move?.Invoke(transform);
        }
    }
}