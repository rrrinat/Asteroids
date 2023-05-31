using UnityEngine;

namespace Asteroids.Partial.Example
{
    public class Service : IService
    {
        public void SomeMethod()
        {
            Debug.Log($"Some Method called.");
        }
    }
}
