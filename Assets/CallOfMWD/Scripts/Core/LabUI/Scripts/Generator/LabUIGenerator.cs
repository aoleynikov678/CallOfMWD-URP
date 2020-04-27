using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace lab.ui
{
    public class UIFieldData
    {
        public UIParamAttribute UIAttribute;
        public FieldInfo FieldInfo;
        public UnityEngine.Object FieldSource;

        public UIFieldData(UIParamAttribute uiAttribute, FieldInfo fieldInfo, UnityEngine.Object fieldSource)
        {
            UIAttribute = uiAttribute;
            FieldInfo = fieldInfo;
            FieldSource = fieldSource;
        }
    }

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
    
    [ExecuteInEditMode]
    public class LabUIGenerator : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Object[] fieldsOwners;
        [SerializeField] private UIGeneratorSettings uiGeneratorSettings;
        [SerializeField] private Transform uiParent;

        [Header("Создание пустого элемента")]
        
        [SerializeField] private UIType emptyElementType;
        
        // add new ui elements and solvers here
        private readonly Dictionary<UIType, AttributeSolver> attributesSolvers = new Dictionary<UIType, AttributeSolver>
        {
            {UIType.Selector, new UISelectorSolver()},
            {UIType.Checkbox, new UICheckboxSolver()},
            {UIType.Slider, new UISliderSolver()},
            {UIType.Input, new UIInputFieldSolver()}
        };

        private LabUIPanel uiPanel;
        
        public void GenerateUI()
        {
            CreatePanel();
            
            var fields = FindFieldsByAttribute(typeof(UIParamAttribute));

            foreach (var field in fields)
            {                
                if (attributesSolvers.ContainsKey(field.UIAttribute.UIType))
                {
                    attributesSolvers[field.UIAttribute.UIType].Solve(uiGeneratorSettings, field);
                }
                else
                {
                    Debug.LogError("No such attribute presented among attributesSolvers: " + field.UIAttribute.GetType());
                }
            }

            CreateSpace();
            CreateSaveButton();
        }

        public void GenerateFakeElement()
        {
            uiGeneratorSettings.UIParent = uiParent;
            
            attributesSolvers[emptyElementType].Solve(uiGeneratorSettings, null);
        }

        private List<UIFieldData> FindFieldsByAttribute(Type type)
        {
            List<UIFieldData> fields = new List<UIFieldData>();
            
            foreach (var obj in fieldsOwners)
            {
                if (obj is ScriptableObject || obj is MonoBehaviour)
                {
                    fields = fields.Concat(GetFieldsOfInterest(obj, type)).ToList();
                }
                else if (obj is GameObject)
                {                   
                    MonoBehaviour[] monoBehaviours = (obj as GameObject).GetComponentsInChildren<MonoBehaviour>(true);
                    fields = monoBehaviours.Aggregate(fields, (foundFields, monoBehaviour) => foundFields.Concat(GetFieldsOfInterest(monoBehaviour, type)).ToList());
                }
            }

            return fields;
        }

        private IEnumerable<UIFieldData> GetFieldsOfInterest(UnityEngine.Object obj, Type type)
        {
            return from x in obj.GetType().GetRuntimeFields()
                   where x.IsDefined(type)
                   select new UIFieldData((UIParamAttribute)x.GetCustomAttribute(typeof(UIParamAttribute)), x, obj);
        }

        private void CreatePanel()
        {
            if (uiGeneratorSettings.SettingsPanel)
            {
                uiPanel = Instantiate(uiGeneratorSettings.SettingsPanel);

                if (uiParent)
                {
                    uiPanel.transform.SetParent(uiParent);
                }
                
                uiPanel.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                uiPanel.transform.SetAsLastSibling();

                uiGeneratorSettings.CreatedPanel = uiPanel;
            }
        }

        private void CreateSaveButton()
        {
            var btn = Instantiate(uiGeneratorSettings.SaveButton, uiPanel.ElementsParents.transform, true);
            btn.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            btn.transform.SetAsLastSibling();
        }
        
        private void CreateSpace()
        {
            var space = Instantiate(uiGeneratorSettings.Space, uiPanel.ElementsParents.transform, true);
            space.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            space.transform.SetAsLastSibling();
        }

    }
}