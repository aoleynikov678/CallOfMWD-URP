using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace lab.ui
{
    [CustomEditor(typeof(FillDropdownWithEnum))]
    [CanEditMultipleObjects]
    public class FillDropdownCustomInspector : Editor
    {
        SerializedProperty configScriptableObjectProp;

        void OnEnable()
        {
            configScriptableObjectProp = serializedObject.FindProperty("configScriptableObject");
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.ObjectField(configScriptableObjectProp);
            configScriptableObjectProp.serializedObject.ApplyModifiedProperties();

            FillDropdownWithEnum prefs = (target as FillDropdownWithEnum);
            serializedObject.Update();
            if (prefs.configScriptableObject != null)
            {
                var listOfFieldNames = prefs.configScriptableObject.GetType().GetFields().Where(f => f.FieldType.IsEnum).ToArray();

                if (listOfFieldNames.Length > 0)
                {
                    string[] options = new string[listOfFieldNames.Length];
                    for (int i = 0; i < options.Length; i++)
                    {
                        options[i] = listOfFieldNames[i].Name;
                    }

                    int ind = options.ToList().FindIndex(a => a == prefs.fieldName);
                    if (ind < 0)
                        ind = 0;
                    int index = EditorGUILayout.Popup("Property:", ind, options, EditorStyles.popup);
                    prefs.fieldName = options[index];
                }
            }
        }
    }
}