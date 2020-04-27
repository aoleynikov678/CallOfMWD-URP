using UnityEngine;
using UnityEngine.UI;

namespace lab.ui
{
    public class LabUISlider : LabUIElementWithButtons<float>
    {
        [SerializeField] private float increment = 0.1f;
        
        private Slider unitySlider;
        private float curVal;

        protected override void Awake()
        {
            base.Awake();
            unitySlider = GetComponentInChildren<Slider>();
            unitySlider.onValueChanged.AddListener(SetValue);
            curVal = unitySlider.value;
            text.text = curVal + "";
        }

        public override void SetValue(float val)
        {
            text.text = val + "";
            curVal = unitySlider.value;
        }
        
        protected override void OnNextPressed()
        {
            base.OnNextPressed();

            curVal += increment;
            curVal = Mathf.Clamp(curVal, unitySlider.minValue, unitySlider.maxValue);
            unitySlider.value = curVal;
            
            SetValue(curVal);
            
            unitySlider.onValueChanged?.Invoke(curVal);
        }

        protected override void OnPrevPressed()
        {
            base.OnPrevPressed();
            
            curVal -= increment;
            curVal = Mathf.Clamp(curVal, unitySlider.minValue, unitySlider.maxValue);
            unitySlider.value = curVal;
            
            SetValue(curVal);
            
            unitySlider.onValueChanged?.Invoke(curVal);
        }
    }
}