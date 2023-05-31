using Plugins.DI;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins.GUI.WIndows
{
    [RequireComponent(typeof(CanvasGroup), typeof(Canvas), typeof(GraphicRaycaster))]
    public class WindowBase : MonoBehaviour
    {
        protected IWindowsPresenter windowsPresenter;
        protected IWindowsContainer windowsContainer;

        protected CanvasGroup canvasGroup;
        
        public RectTransform RectTransform { get; private set; }
        
        [Inject]
        public void Construct(IWindowsPresenter windowsPresenter, IWindowsContainer windowsContainer)
        {
            this.windowsPresenter = windowsPresenter;
            this.windowsContainer = windowsContainer;
        }
        
        public virtual void Initialize()
        {
            RectTransform = GetComponent<RectTransform>();
            //RectTransform.localScale = Vector3.zero;

            canvasGroup = GetComponent<CanvasGroup>();
        }
        
        public virtual void Show()
        {
            if (!gameObject.activeSelf) gameObject.SetActive(true);
        }
        
        public virtual void Close()
        {
            if (gameObject == null) return;

            canvasGroup.interactable = false;
            
            windowsPresenter.Close(this);
        }
    }
}
