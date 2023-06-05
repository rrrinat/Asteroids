using Asteroids.Partial.Gameplay.Configs;
using Plugins.DI;
using UnityEngine;

namespace Asteroids.Partial.Installers
{
    public class ConfigsInstaller : MonoInstaller
    {
        [SerializeField] private SpaceshipConfig spaceshipConfig;

        public override void Install(DIContainer container)
        {
            container.RegisterInstance<SpaceshipConfig>(spaceshipConfig);
        }
    }
}