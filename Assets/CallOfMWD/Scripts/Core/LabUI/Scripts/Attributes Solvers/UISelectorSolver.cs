using System;
using UnityEngine;

namespace lab.ui
{
    public class UISelectorSolver : AttributeSolver
    {
        private LabUISelector selector;
        
        public override void Solve(UIGeneratorSettings uiGeneratorSettings, UIFieldData fieldData)
        {
            if (uiGeneratorSettings.CreatedPanel)
            {
                selector = GameObject.Instantiate(uiGeneratorSettings.SelectorPrefab,
                    uiGeneratorSettings.CreatedPanel.ElementsParents.transform,
                    true);
            }
            else
            {
                selector = GameObject.Instantiate(uiGeneratorSettings.SelectorPrefab,
                    uiGeneratorSettings.UIParent,
                    true);
            }

            if (fieldData == null)
                return;
            
            selector.name = "Selector " + fieldData.FieldInfo.Name;
            
            if (!string.IsNullOrEmpty(fieldData.UIAttribute.Header)) selector.SetHeader(fieldData.UIAttribute.Header);
            if (!string.IsNullOrEmpty(fieldData.UIAttribute.Description)) selector.SetHeaderDescription(fieldData.UIAttribute.Description);           
            
            FillSelectorWithEnum fillSelectorWithEnum = selector.gameObject.AddComponent<FillSelectorWithEnum>();
            
            fillSelectorWithEnum.FieldSourceObject = fieldData.FieldSource;
            fillSelectorWithEnum.FieldName = fieldData.FieldInfo.Name;

            SettingsBinding settingsBinding = selector.gameObject.AddComponent<SettingsBinding>();
            
            settingsBinding.FieldSourceObject = fieldData.FieldSource;
            settingsBinding.FieldName = fieldData.FieldInfo.Name;
        }
                
    }
}