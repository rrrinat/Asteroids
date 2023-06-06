using Asteroids.Partial.Gameplay.Steering;
using Plugins.DI;
using UnityEngine;

namespace Asteroids.Partial.Gameplay.Entities
{
    public class Spaceship : IUnit
    {
        private IMoving moveComponent;

        private SpaceshipView view;
        
        [Inject]
        public void Construct(IMoving moveComponent)
        {
            this.moveComponent = moveComponent;
            
            var defaultInput = new DefaultInput();
            defaultInput.Enable();
            
            defaultInput.Spaceship.Forward.started += moveComponent.ForwardStarted;
            defaultInput.Spaceship.Forward.canceled += moveComponent.ForwardCanceled;
            
            defaultInput.Spaceship.Rotation.performed += moveComponent.RotationPerformed;
            defaultInput.Spaceship.Rotation.canceled += moveComponent.RotationCanceled;
        }
        
        public void Initialize()
        {
            var prefab = Resources.Load<GameObject>("Spaceship");
            view = GameObject.Instantiate(prefab).GetComponent<SpaceshipView>();
            view.SetMove(moveComponent.Update);
        }
    }
}