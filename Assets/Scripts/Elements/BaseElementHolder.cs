using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BaseElementHolder : EventTrigger
{
	[SerializeField] private BaseElement m_element;

	protected BaseSlot m_startSlot;
	protected BaseSlot m_targetSlot;
	protected BaseSlot m_currentSlot;
	protected SlotManager m_slotManager;
	protected Image m_image;

	public override void OnBeginDrag(PointerEventData eventData)
	{
		base.OnBeginDrag(eventData);

		GetSlotManager();

		transform.SetParent(m_slotManager.GetHeldContainer());

		//Highlight 1st available slot
		//Set new parent to avoid mask
	}

	public override void OnDrag(PointerEventData eventData)
	{
		base.OnDrag(eventData);

		transform.position+=(Vector3)eventData.delta;

		foreach(var slot in m_slotManager.GetMergeSlots())
		{
			if(RectTransformUtility.RectangleContainsScreenPoint(slot.m_rect, Input.mousePosition))
			{
				if(slot.IsEmpty())
				{
					m_targetSlot = slot;
					break;
				}
				m_targetSlot = null;
			}
		}
	}

	public override void OnEndDrag(PointerEventData eventData)
	{
		base.OnEndDrag(eventData);

		Remove();

		if(m_targetSlot != null)
		{
			Place();
		}

		//Unhighlight slot
		//Reset if not over slot
		//Place in slot and parent if over slot
	}

	public void SetElement(BaseElement element)
	{
		m_element = element;
	}

	public BaseElement GetElement()
	{
		return m_element;
	}

	public void Setup(BaseSlot slot)
	{
		if(m_element.m_icon != null)
		{
			m_image.sprite = m_element.m_icon;
		}

		m_startSlot = slot;
		Reset();
	}

	private void Reset()
	{
		transform.SetParent(m_startSlot.transform);
		transform.position = m_startSlot.transform.position;
	}

	public void Place()
	{
		m_currentSlot = m_targetSlot;
		m_currentSlot.SetElementHolder(this);

		transform.SetParent(m_currentSlot.transform);
		transform.position = m_currentSlot.transform.position;

		m_slotManager.CheckMerge();

		m_targetSlot = null;
	}

	public void Remove()
	{
		if(m_currentSlot != null)
		{
			m_currentSlot.RemoveElementHolder();
			m_currentSlot = null;
		}
		
		Reset();
	}

	private void GetSlotManager()
	{
		if(m_slotManager == null)
		{
			m_slotManager = SlotManager.Instance;
		}
	}

	public void PlaceResult()
	{
		GetSlotManager();
		m_targetSlot = m_slotManager.GetResultSlot();
		Place();
	}
}
