using System;
using UnityEngine;
using UnityEngine.UI;

namespace lab.ui
{
    [Serializable]
    public class UIGeneratorSettings
    {
        [Header("Фоновая панель")]
        public LabUIPanel SettingsPanel;
        
        [Header("Префабы элементов UI")]
        public LabUISelector SelectorPrefab;
        public LabUICheckbox CheckboxPrefab;
        public LabUISlider SliderPrefab;
        public LabUIInput InputPrefab;

        [Header("Кнопка сохранения")]
        public Button SaveButton;

        [Header("Разделитель")] 
        public GameObject Space;

        [HideInInspector]
        public LabUIPanel CreatedPanel;

        [HideInInspector] 
        public Transform UIParent;
    }
}