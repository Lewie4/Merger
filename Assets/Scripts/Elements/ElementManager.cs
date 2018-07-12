using System.Collections.Generic;
using UnityEngine;

public class ElementManager : Singleton<ElementManager> 
{
	[SerializeField] private List<BaseElement> m_startingElements;
	[SerializeField] private List<BaseCombination> m_allCombinations;

	private List<BaseElement> m_collectedElements;

	private void Awake()
	{
		m_collectedElements = new List<BaseElement>();
	}

	private void Start()
	{
		foreach(var element in m_startingElements)
		{
			SlotManager.Instance.CreateInventorySlot(element);
		}
	}

	public BaseElement CheckMerge(BaseElement x, BaseElement y)
	{
		foreach(var combination in m_allCombinations)
		{
			if((combination.m_element1 == x && combination.m_element2 == y)
			|| (combination.m_element1 == y && combination.m_element2 == x))
			{
				return combination.m_result;
			}
		}

		return null;
	}

	public bool CheckCollected(BaseElement element)
	{
		return m_collectedElements.Contains(element);
	}

	public void CollectElement(BaseElement element)
	{
		m_collectedElements.Add(element);
	}

#if UNITY_EDITOR
	public void SetAllCombinations(List<BaseCombination> combinations)
	{
		m_allCombinations = combinations;
	}
#endif
}
