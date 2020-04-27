using UnityEngine;
using UnityEngine.UI;

namespace lab.ui
{
    public class UIInputFieldSolver : AttributeSolver
    {
        private LabUIInput input;
        
        public override void Solve(UIGeneratorSettings uiGeneratorSettings, UIFieldData fieldData)
        {
            input = GameObject.Instantiate(uiGeneratorSettings.InputPrefab, 
                                            uiGeneratorSettings.CreatedPanel.ElementsParents.transform, 
                                            true);

            if (fieldData == null)
                return;
            
            input.name = "Input " + fieldData.FieldInfo.Name;
            
            if (!string.IsNullOrEmpty(fieldData.UIAttribute.Header)) input.SetHeader(fieldData.UIAttribute.Header);
            if (!string.IsNullOrEmpty(fieldData.UIAttribute.Description)) input.SetHeaderDescription(fieldData.UIAttribute.Description);

            InputField unityInput = input.GetComponentInChildren<InputField>();
            
            SettingsBinding settingsBinding = unityInput.gameObject.AddComponent<SettingsBinding>();
            settingsBinding.FieldSourceObject = fieldData.FieldSource;
            settingsBinding.FieldName = fieldData.FieldInfo.Name;
        }
    }
}