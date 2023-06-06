using System;
using UnityEngine;

namespace Asteroids.Partial.Gameplay.Entities
{
    public class SpaceshipView : MonoBehaviour
    {
        private Action<Transform> move;

        public void SetMove(Action<Transform> move)
        {
            this.move = move;
        }
        
        private void Update()
        {
            move?.Invoke(transform);
        }
    }
}