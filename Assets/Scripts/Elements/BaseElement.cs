using UnityEngine;

[CreateAssetMenu(fileName = "Element_001", menuName = "Merger/Create Base Element")]
public class BaseElement : ScriptableObject 
{
	public string m_id;
	public Sprite m_icon;
	[TextArea] public string m_description;
}
