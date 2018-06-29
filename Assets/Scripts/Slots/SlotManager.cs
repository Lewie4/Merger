using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : Singleton<SlotManager> 
{
	[Header("Combination")]
	[SerializeField] private List<MergeSlot> m_mergeSlots;
	[SerializeField] private ResultSlot m_resultSlot;

	[Header("Inventory")]
	[SerializeField] private GameObject m_inventorySlotPrefab;
	[SerializeField] private Transform m_inventoryHolder;
	[SerializeField] private List<InventorySlot> m_inventorySlots;
	
	[Header("Held")]
	[SerializeField] private Transform m_heldContainer;


	private ElementManager m_elementManager;

	private void Start()
	{
		m_elementManager = ElementManager.Instance;
	}

	public List<MergeSlot> GetMergeSlots()
	{
		return m_mergeSlots;
	}

	public ResultSlot GetResultSlot()
	{
		return m_resultSlot;
	}

	public Transform GetHeldContainer()
	{
		return m_heldContainer;
	}

	public InventorySlot CreateInventorySlot(BaseElement element)
	{
		InventorySlot slot = Instantiate(m_inventorySlotPrefab, m_inventoryHolder).GetComponent<InventorySlot>();

		slot.SetElement(element);
		m_inventorySlots.Add(slot);

		return slot;
	}

	public void CheckMerge()
	{
		bool mergeSlotsFilled = true;

		foreach(var slot in m_mergeSlots)
		{
			if(slot.IsEmpty())
			{
				mergeSlotsFilled = false;
				break;
			}
		}

		if(mergeSlotsFilled)
		{
			Debug.Log(string.Format("Slot 1: {0}, Slot 2: {1}", m_mergeSlots[0].GetElement().m_name, m_mergeSlots[1].GetElement().m_name));
			var createdElement = m_elementManager.CheckMerge(m_mergeSlots[0].GetElement(), m_mergeSlots[1].GetElement());

			if(createdElement != null)
			{
				Debug.Log(string.Format("You created: {0}!", createdElement.m_name));

				if(!m_elementManager.CheckCollected(createdElement))
				{
					m_elementManager.CollectElement(createdElement);
					var slot = CreateInventorySlot(createdElement);
					slot.GetElementHolder().PlaceResult();
				}

			}
			
		}
	}
}
