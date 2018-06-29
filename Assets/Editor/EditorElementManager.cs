using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ElementManager))]
public class EditorElementManager : Editor 
{
	private ElementManager m_elementManager;

	private void OnEnable()
	{
		m_elementManager = (ElementManager)target;
	}

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		if(GUILayout.Button("Update Combinations"))
		{
			SetCombinations();
		}
	}

	private void SetCombinations()
	{
		List<BaseCombination> combinations = new List<BaseCombination>();

		m_elementManager.SetAllCombinations(combinations);
	}
}
