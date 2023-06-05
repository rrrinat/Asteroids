using Asteroids.Partial.Gameplay.Steering.Configs;
using Plugins.DI;
using UnityEngine;

namespace Asteroids.Partial.Gameplay.Steering
{
    public class MoveComponent
    {
        private IMover mover;

        private MovementConfig movementConfig;

        [Inject]
        public void Construct(MovementConfig movementConfig)
        {
            this.movementConfig = movementConfig;
        }

        public MoveComponent()
        {
            //mover = new DefaultMover();    
        }

        public void Update()
        {
            
        }
    }
}