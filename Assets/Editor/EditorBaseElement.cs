using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BaseElement))]
public class EditorBaseElement : Editor 
{
	private BaseElement m_element;

	private void OnEnable()
	{
		m_element = (BaseElement)target;
		Save();
	}

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		if(GUILayout.Button("Save"))
		{
			Save();
		}
	}

	private void Save()
	{
		string assetPath =  AssetDatabase.GetAssetPath(m_element.GetInstanceID());

		if(string.IsNullOrEmpty(m_element.m_id))
		{
			m_element.m_id = m_element.name;
		}
		else
		{
			AssetDatabase.RenameAsset(assetPath, m_element.m_id);
		}

		AssetDatabase.SaveAssets();
	}
}
