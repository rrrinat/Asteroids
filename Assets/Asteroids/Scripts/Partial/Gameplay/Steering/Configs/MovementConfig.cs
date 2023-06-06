using UnityEngine;

namespace Asteroids.Partial.Gameplay.Steering.Configs
{
    [CreateAssetMenu(fileName = "Movement Config", menuName = "Asteroids/Partial/Gameplay/Steering/Movement Config", order = 0)]
    public class MovementConfig : ScriptableObject
    {
        public float MovementSpeed;
        public float RotationSpeed;
        
        public float RotationAmplification;
        public float RotationDamping;
        
        public float MovementAmplification;
        public float MovementDamping;
    }
}