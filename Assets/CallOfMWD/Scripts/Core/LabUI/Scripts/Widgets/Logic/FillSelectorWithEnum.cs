using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;

namespace lab.ui
{
    public class FillSelectorWithEnum : MonoBehaviour
    {
        public UnityEngine.Object FieldSourceObject;
        
        private FieldInfo myFieldInfo;
        
        public string FieldName;
        private string lastFieldName;
        private LabUISelector selector;
        
        private void Awake()
        {
            Type myTypeA = FieldSourceObject.GetType();
            myFieldInfo = myTypeA.GetField(FieldName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
		
            ReInit();
        }

        private void Update()
        {
            if (lastFieldName != FieldName)
            {
                lastFieldName = FieldName;
                ReInit();
            }
        }

        private void ReInit()
        {
            selector = GetComponentInChildren<LabUISelector>();
            if (selector != null)
            {
                FillSelector();
            }
        }
		
        private void FillSelector()
        {
            selector.ClearOptions();
            List<string> options = new List<string>();
            List<string> descriptions = new List<string>();
			
            foreach (var f in Enum.GetValues(myFieldInfo.FieldType))
            {
                string data = f.ToString();
                //string description = GetEnumDescription((Enum) f);
                
                options.Add(data);
                //descriptions.Add(description);
            }

            selector.SetOptions(options);
            //selector.SetDescriptions(descriptions);
            //selector.Ready = true;
        }
		
        // TODO Add Descriptions!
        private string GetEnumDescription(Enum value)
        {
            Debug.Log("GetEnumDescription " + value);

            FieldInfo fi = value.GetType().GetField(value.ToString());
            
            Debug.Log("fi " + fi);

            if (fi == null)
            {
                Debug.Log("FI IS NULL");
            }

            DescriptionAttribute[] attributes = (DescriptionAttribute[]) fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}