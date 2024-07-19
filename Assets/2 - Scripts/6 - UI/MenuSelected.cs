using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuSelected : MonoBehaviour
{
	private EventTrigger _eventTrigger;

	private delegate void EventTriggerDelegate(BaseEventData data);
	private EventTriggerDelegate _eventTriggerDelegate;
	private void Awake()
	{
		_eventTrigger = gameObject.AddComponent<EventTrigger>();

		// Create a new entry for the EventTrigger

		EventTrigger.Entry select = new EventTrigger.Entry();
		EventTrigger.Entry pointerEnter = new EventTrigger.Entry();

		// Set the event type to pointer enter
		select.eventID = EventTriggerType.Select;
		pointerEnter.eventID = EventTriggerType.PointerEnter;

		// Add a listener
		//select.callback.AddListener((data) => { _eventTriggerDelegate((PointerEventData)data); });
		select.callback.AddListener((data) => { OnSelect((BaseEventData)data); });
		pointerEnter.callback.AddListener((data) => { OnSelect((BaseEventData)data); });

		//// Add the entry to the EventTrigger
		_eventTrigger.triggers.Add(select);
		_eventTrigger.triggers.Add(pointerEnter);

		//_eventTriggerDelegate += OnPointerEnter;
	}

	private void OnPointerEnter(BaseEventData data)
	{
		AudioManager.Instance.Play("Bounce");
	}

	public void OnSelect(BaseEventData data)
	{
		AudioManager.Instance.Play("Bounce");
	}


}
