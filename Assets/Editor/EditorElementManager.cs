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

		string[] guids = AssetDatabase.FindAssets("t:BaseCombination");

		foreach(var guid in guids)
		{
			combinations.Add((BaseCombination)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), typeof(BaseCombination)));
		}

		m_elementManager.SetAllCombinations(combinations);
	}
}
