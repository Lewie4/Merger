using UnityEngine;

[CreateAssetMenu(fileName = "Combination_001", menuName = "Merger/Create Base Combination")]
public class BaseCombination : ScriptableObject
{
	public BaseElement m_element1;
	public BaseElement m_element2;
	public BaseElement m_result;
}
