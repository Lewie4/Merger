using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : Singleton<StoryManager> 
{
	[Header("Background")]
	[SerializeField] private GameObject m_storyOverlay;
	[SerializeField] private Image m_background;
	
	[Header("Text")]
	[SerializeField] private TextMeshProUGUI m_text;

	[Header("Image")]
	[SerializeField] private Image m_elementImage;

	[Header("Settings")]
	[SerializeField] private float m_fadeInTime = 0.5f;

	private float m_timeStartedLerp;
	private bool m_fadeIn;

	private void Start()
	{
		m_storyOverlay.SetActive(false);
	}

	private void Update()
	{
		if (m_fadeIn)
		{
			float timeSinceStarted = Time.time - m_timeStartedLerp;
			float percentageComplete = timeSinceStarted / m_fadeInTime;
			
			FadeAllElements(percentageComplete);
			
			if (percentageComplete >= 1)
			{
				m_fadeIn = false;
			}
		}
	}

	public void NewElementCreated(BaseElement element)
	{
		m_storyOverlay.SetActive(true);
		m_text.text = element.m_description;
		m_elementImage.sprite = element.m_icon;
		
		StartFadeIn();
	}

	private void StartFadeIn()
	{
		m_fadeIn = true;
		m_timeStartedLerp = Time.time;
		FadeAllElements(0);
	}

	private void FadeAllElements(float percentage)
	{
		m_background.color = FadeAlpha(m_background.color, percentage);
		m_text.color = FadeAlpha(m_text.color, percentage);
		m_elementImage.color = FadeAlpha(m_elementImage.color, percentage);
	}
	

	private Color FadeAlpha(Color colour, float percentage)
	{
		Color tempColour = colour;
		tempColour.a = percentage;
		return tempColour;
	}

	public void Dismiss()
	{
		if (!m_fadeIn)
		{
			m_storyOverlay.SetActive(false);
		}
	}
}
