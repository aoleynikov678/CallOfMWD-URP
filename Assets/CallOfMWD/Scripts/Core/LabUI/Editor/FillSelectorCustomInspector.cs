using System.Linq;
using System.Reflection;
using UnityEditor;

namespace lab.ui
{
    [CustomEditor(typeof(FillSelectorWithEnum))]
    [CanEditMultipleObjects]
    public class FillSelectorCustomInspector : Editor
    {
        SerializedProperty configScriptableObjectProp;

        void OnEnable()
        {
            configScriptableObjectProp = serializedObject.FindProperty("FieldSourceObject");
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.ObjectField(configScriptableObjectProp);
            configScriptableObjectProp.serializedObject.ApplyModifiedProperties();

            FillSelectorWithEnum prefs = (target as FillSelectorWithEnum);
            serializedObject.Update();
            if (prefs.FieldSourceObject != null)
            {
                var listOfFieldNames = prefs.FieldSourceObject.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic).Where(f => f.FieldType.IsEnum).ToArray();

                if (listOfFieldNames.Length > 0)
                {
                    string[] options = new string[listOfFieldNames.Length];
                    for (int i = 0; i < options.Length; i++)
                    {
                        options[i] = listOfFieldNames[i].Name;
                    }

                    int ind = options.ToList().FindIndex(a => a == prefs.FieldName);
                    if (ind < 0)
                        ind = 0;
                    int index = EditorGUILayout.Popup("Property:", ind, options, EditorStyles.popup);
                    prefs.FieldName = options[index];
                }
            }
        }
    }
}