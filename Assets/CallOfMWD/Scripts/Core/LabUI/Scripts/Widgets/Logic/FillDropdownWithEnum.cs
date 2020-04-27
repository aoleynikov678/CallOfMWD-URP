using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace lab.ui
{
	public class FillDropdownWithEnum : MonoBehaviour
	{
		public ScriptableObject configScriptableObject;
        
		private FieldInfo myFieldInfo;
        
		public string fieldName;
		private string lastFieldName;
		private Dropdown dropdown;
        
		private void Awake()
		{
			Type myTypeA = configScriptableObject.GetType();
			myFieldInfo = myTypeA.GetField(fieldName);
		
			ReInit();
		}

		private void Update()
		{
			if (lastFieldName != fieldName)
			{
				lastFieldName = fieldName;
				ReInit();
			}
		}

		private void ReInit()
		{
			dropdown = GetComponent<Dropdown>();
			if (dropdown != null)
			{
				FillDropdown();
			}
		}
		
		private void FillDropdown()
		{
			dropdown.options.Clear();
			List<Dropdown.OptionData> optionDataList = new List<Dropdown.OptionData>();
			
			foreach (var f in Enum.GetValues(myFieldInfo.FieldType))
			{
				string data = GetEnumDescription((Enum) f);
				
				Dropdown.OptionData optionData = new Dropdown.OptionData(data);
				optionDataList.Add(optionData);
			}

			dropdown.options = optionDataList;
		}
		
		private string GetEnumDescription(Enum value)
		{
			FieldInfo fi = value.GetType().GetField(value.ToString());

			DescriptionAttribute[] attributes =
				(DescriptionAttribute[])fi.GetCustomAttributes(
					typeof(DescriptionAttribute),
					false);

			if (attributes.Length > 0)
				return attributes[0].Description;
			else
				return value.ToString();
		}
		
	}
}