using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Combination_001", menuName = "Element/Create Base Combination")]
public class BaseCombination : ScriptableObject
{
	public BaseElement m_element1;
	public BaseElement m_element2;
	public BaseElement m_result;
}
