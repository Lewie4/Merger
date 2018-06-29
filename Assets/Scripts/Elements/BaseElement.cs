using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Element_001", menuName = "Element/Create Base Element")]
public class BaseElement : ScriptableObject 
{
	public string m_id;
	public string m_name;
	public Sprite m_icon;
	[TextArea] public string m_description;
}
