using UnityEngine;

namespace lab.ui
{
    public class UICheckboxSolver : AttributeSolver
    {
        private LabUICheckbox checkbox;
        
        public override void Solve(UIGeneratorSettings uiGeneratorSettings, UIFieldData fieldData)
        {
            checkbox = GameObject.Instantiate(uiGeneratorSettings.CheckboxPrefab, 
                                              uiGeneratorSettings.CreatedPanel.ElementsParents.transform, 
                                              true);

            if (fieldData == null)
                return;
            
            checkbox.name = "Checkbox " + fieldData.FieldInfo.Name;
            
            if (!string.IsNullOrEmpty(fieldData.UIAttribute.Header)) checkbox.SetHeader(fieldData.UIAttribute.Header);
            if (!string.IsNullOrEmpty(fieldData.UIAttribute.Description)) checkbox.SetHeaderDescription(fieldData.UIAttribute.Description);
            
            SettingsBinding settingsBinding = checkbox.gameObject.AddComponent<SettingsBinding>();
            
            settingsBinding.FieldSourceObject = fieldData.FieldSource;
            settingsBinding.FieldName = fieldData.FieldInfo.Name;
        }
    }
}