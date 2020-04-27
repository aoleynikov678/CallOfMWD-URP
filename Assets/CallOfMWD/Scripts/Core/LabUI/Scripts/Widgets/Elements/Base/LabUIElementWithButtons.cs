using UnityEngine;
using UnityEngine.UI;

namespace lab.ui
{
    public class LabUIElementWithButtons<T> : LabUIElement<T>
    {
        [Header("Кнопки навигации")]
        
        [SerializeField]
        protected Button nextButton;
        
        [SerializeField]
        protected Button prevButton;
        
        protected override void Awake()
        {
            if (nextButton)
            {
                nextButton.onClick.AddListener(OnNextPressed);
            }
            
            if (prevButton)
            {
                prevButton.onClick.AddListener(OnPrevPressed);
            }
        }

        protected override void OnDestroy()
        {
            nextButton.onClick.RemoveAllListeners();
            prevButton.onClick.RemoveAllListeners();
        }

        protected virtual void OnNextPressed()
        {
        }
        
        protected virtual void OnPrevPressed()
        {
        }

        public override void SetValue(T val)
        {
        }
    }
}