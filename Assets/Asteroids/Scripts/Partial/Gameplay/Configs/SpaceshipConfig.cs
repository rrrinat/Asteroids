using UnityEngine;

namespace Asteroids.Partial.Gameplay.Configs
{
    [CreateAssetMenu(fileName = "Spaceship Config", menuName = "Asteroids/Partial/Gameplay/Spaceship Config", order = 0)]
    public class SpaceshipConfig : ScriptableObject
    {
        public float Speed;
        
    }
}