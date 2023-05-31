using UnityEngine;

namespace Plugins.GUI.WIndows
{
    public class WindowBase : MonoBehaviour
    {
        public RectTransform RectTransform { get; private set; }

        public void Initialize()
        {
            RectTransform = GetComponent<RectTransform>();
        }
    }
}
