using Asteroids.Partial.Gameplay.GameStates;
using Asteroids.Partial.GameServices;
using Plugins.DI;
using UnityEngine;

namespace Asteroids.Partial.Gameplay
{
    public class GamePresenter : MonoBehaviour
    {
        private InstallService installService;
        
        private IGameStateMachine gameStateMachine;
        
        public void Start()
        {
            var container = new DIContainer();
            container.RegisterInstance<DIContainer>(container);
            
            installService = new InstallService();
            installService.Install(container);
            
            gameStateMachine = container.Resolve<IGameStateMachine>();
            gameStateMachine.Initialize();
        }

        private void Update()
        {
            gameStateMachine.Update();
        }
    }
}
