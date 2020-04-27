using UnityEditor;
using System.Linq;
using System.Reflection;

namespace lab.ui
{
	[CustomEditor(typeof(SettingsBinding))]
	[CanEditMultipleObjects]
	public class SettingsBindingCustomInspector : Editor
	{
		SerializedProperty fieldSourceProp;

		void OnEnable()
		{
			fieldSourceProp = serializedObject.FindProperty("FieldSourceObject");
		}

		public override void OnInspectorGUI()
		{
			EditorGUILayout.ObjectField(fieldSourceProp);
			fieldSourceProp.serializedObject.ApplyModifiedProperties();

			SettingsBinding prefs = (target as SettingsBinding);
			serializedObject.Update();
			if (prefs.FieldSourceObject != null)
			{
				var listOfFieldNames = prefs.FieldSourceObject.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);

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