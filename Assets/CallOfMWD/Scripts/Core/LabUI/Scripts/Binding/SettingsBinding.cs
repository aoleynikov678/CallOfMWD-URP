using System;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace lab.ui
{
	public class SettingsBinding : MonoBehaviour
	{
		public UnityEngine.Object FieldSourceObject;

		public string FieldName;
		private FieldInfo myFieldInfo;
		private Selectable editableComponent;

		private object lastFieldValue;

		private void Awake()
		{
			Type myTypeA = FieldSourceObject.GetType();
	
			
			myFieldInfo = myTypeA.GetField(FieldName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
		}

		private void Update()
		{
			object fieldValue = myFieldInfo.GetValue(FieldSourceObject);

			if (EventSystem.current != null && editableComponent != null
			                                && editableComponent.gameObject ==
			                                EventSystem.current.currentSelectedGameObject)
			{
				return;
			}

			if (fieldValue != null && lastFieldValue == null ||
			    fieldValue != null && fieldValue.ToString() != lastFieldValue.ToString())
			{
				lastFieldValue = fieldValue;
				ReInitValues(fieldValue);
			}
		}

		private void ReInitValues(object fieldValue)
		{
			InputField input = GetComponent<InputField>();
			if (input != null)
			{
				editableComponent = input;
				input.onEndEdit.RemoveListener(OnInputChanged);
				input.text = fieldValue.ToString();
				input.onEndEdit.AddListener(OnInputChanged);
			}
			
			TMP_InputField tmp_input = GetComponent<TMP_InputField>();
			if (tmp_input != null)
			{
				editableComponent = tmp_input;
				tmp_input.onEndEdit.RemoveListener(OnInputChanged);
				tmp_input.text = fieldValue.ToString();
				tmp_input.onEndEdit.AddListener(OnInputChanged);
			}

			Toggle toggle = GetComponent<Toggle>();
			if (toggle != null)
			{
				editableComponent = toggle;
				toggle.onValueChanged.RemoveListener(OnToggleChanged);
				toggle.isOn = (bool) fieldValue;
				toggle.onValueChanged.AddListener(OnToggleChanged);
			}

			Text text = GetComponent<Text>();
			if (text != null)
			{
				if (fieldValue is float)
					text.text = ((float) fieldValue).ToString("0.00");
				else if (fieldValue is double)
					text.text = ((double) fieldValue).ToString("0.00");
				else
					text.text = fieldValue.ToString();
			}

			Slider slider = GetComponent<Slider>();
			if (slider != null)
			{
				editableComponent = slider;
				slider.onValueChanged.RemoveListener(OnSliderChanged);
				slider.value = float.Parse(fieldValue.ToString());
				slider.onValueChanged.AddListener(OnSliderChanged);
			}

			Dropdown dropdown = GetComponent<Dropdown>();
			if (dropdown != null)
			{
				editableComponent = dropdown;
				dropdown.onValueChanged.RemoveListener(OnDropdownChanged);
				dropdown.value = (int) fieldValue;
				dropdown.onValueChanged.AddListener(OnDropdownChanged);
			}

			LabUISelector labUiSelector = GetComponent<LabUISelector>();
			if (labUiSelector != null)
			{
				editableComponent = labUiSelector;
				labUiSelector.OnValueChanged.RemoveListener(OnSelectorChanged);
				labUiSelector.SetValue(fieldValue.ToString());
				labUiSelector.OnValueChanged.AddListener(OnSelectorChanged);
			}


			LabUICheckbox labUiCheckbox = GetComponent<LabUICheckbox>();
			if (labUiCheckbox != null)
			{
				editableComponent = labUiSelector;
				labUiCheckbox.OnValueChanged.RemoveAllListeners();
				labUiCheckbox.SetValue((bool)fieldValue);
				labUiCheckbox.OnValueChanged.AddListener(OnCheckboxChanged);
			}

		}

		private void OnInputChanged(string value)
		{
			if (myFieldInfo.FieldType == typeof(int))
			{
				myFieldInfo.SetValue(FieldSourceObject, int.Parse(value));
				lastFieldValue = int.Parse(value);
			}
			else if (myFieldInfo.FieldType == typeof(float))
			{
				myFieldInfo.SetValue(FieldSourceObject, float.Parse(value));
				lastFieldValue = float.Parse(value);
			}
			else if (myFieldInfo.FieldType == typeof(double))
			{
				myFieldInfo.SetValue(FieldSourceObject, double.Parse(value));
				lastFieldValue = double.Parse(value);
			}
			else
			{
				myFieldInfo.SetValue(FieldSourceObject, value);
				lastFieldValue = value;
			}
		}

		private void OnToggleChanged(bool value)
		{
			lastFieldValue = value;
			myFieldInfo.SetValue(FieldSourceObject, value);
		}

		private void OnSliderChanged(float value)
		{

			if (myFieldInfo.FieldType == typeof(int))
			{
				myFieldInfo.SetValue(FieldSourceObject, Mathf.FloorToInt(value));
				lastFieldValue = Mathf.FloorToInt(value);
			}
			else if (myFieldInfo.FieldType == typeof(double))
			{
				myFieldInfo.SetValue(FieldSourceObject, (double) value);
				lastFieldValue = (double) value;
			}
			else
			{
				myFieldInfo.SetValue(FieldSourceObject, value);
				lastFieldValue = value;
			}

			myFieldInfo.SetValue(FieldSourceObject, lastFieldValue);
		}

		private void OnDropdownChanged(int value)
		{
			myFieldInfo.SetValue(FieldSourceObject, value);
			lastFieldValue = value;
		}

		private void OnSelectorChanged(string value, int index)
		{
			if (myFieldInfo.FieldType.IsEnum)
			{
				myFieldInfo.SetValue(FieldSourceObject, Enum.Parse(myFieldInfo.FieldType, value));
			}
			else if (myFieldInfo.FieldType == typeof(int))
			{
				myFieldInfo.SetValue(FieldSourceObject, int.Parse(value));
			}
			else
			{
				myFieldInfo.SetValue(FieldSourceObject, value);
			}
			
			
			lastFieldValue = value;
		}
		
		private void OnCheckboxChanged(bool value)
		{
			myFieldInfo.SetValue(FieldSourceObject, value);
			lastFieldValue = value;
		}
	}
}
