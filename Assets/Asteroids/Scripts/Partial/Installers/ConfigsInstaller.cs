using Asteroids.Partial.Gameplay.Steering.Configs;
using Plugins.DI;
using UnityEngine;

namespace Asteroids.Partial.Installers
{
    public class ConfigsInstaller : MonoInstaller
    {
        [SerializeField] private MovementConfig movementConfig;

        public override void Install(DIContainer container)
        {
            container.RegisterInstance<MovementConfig>(movementConfig);
        }
    }
}