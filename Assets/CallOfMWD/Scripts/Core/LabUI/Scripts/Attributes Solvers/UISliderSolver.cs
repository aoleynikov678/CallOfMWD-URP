using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace lab.ui
{
    public class UISliderSolver : AttributeSolver
    {
        private LabUISlider slider;
        
        public override void Solve(UIGeneratorSettings uiGeneratorSettings, UIFieldData fieldData)
        {
            slider = GameObject.Instantiate(uiGeneratorSettings.SliderPrefab, 
                                            uiGeneratorSettings.CreatedPanel.ElementsParents.transform, 
                                            true);
            
            if (fieldData == null)
                return;
            
            slider.name = "Slider " + fieldData.FieldInfo.Name;
            
            if (!string.IsNullOrEmpty(fieldData.UIAttribute.Header)) slider.SetHeader(fieldData.UIAttribute.Header);
            if (!string.IsNullOrEmpty(fieldData.UIAttribute.Description)) slider.SetHeaderDescription(fieldData.UIAttribute.Description);

            Slider unitySlider = slider.GetComponentInChildren<Slider>();
            
            SettingsBinding settingsBinding = unitySlider.gameObject.AddComponent<SettingsBinding>();
            settingsBinding.FieldSourceObject = fieldData.FieldSource;
            settingsBinding.FieldName = fieldData.FieldInfo.Name;
            
            // get range attribute and apply it to Slider
            var attrs = fieldData.FieldInfo.GetCustomAttributes().ToList();

            foreach (var attr in attrs)
            {
                if (attr is RangeAttribute attribute)
                {
                    unitySlider.minValue = attribute.min;
                    unitySlider.maxValue = attribute.max;
                }
            }
        }
    }
}