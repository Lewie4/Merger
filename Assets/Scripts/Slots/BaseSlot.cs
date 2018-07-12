using UnityEngine;

public class BaseSlot : MonoBehaviour
{
	[SerializeField] protected BaseElementHolder m_elementHolder = null;
	[HideInInspector] public RectTransform m_rect;

	private void Awake()
	{
		m_rect = GetComponent<RectTransform>();
	}

	public void SetElement(BaseElement element)
	{
		m_elementHolder.SetElement(element);
		m_elementHolder.Setup(this);
	}

	public BaseElement GetElement()
	{
		return m_elementHolder.GetElement();
	}

	public void SetElementHolder(BaseElementHolder elementHolder)
	{
		m_elementHolder = elementHolder;
	}

	public BaseElementHolder GetElementHolder()
	{
		return m_elementHolder;
	}

	public void RemoveElementHolder()
	{
		if(m_elementHolder != null)
		{
			m_elementHolder = null;
		}
	}

	public bool IsEmpty()
	{
		return m_elementHolder == null;
	}
}
