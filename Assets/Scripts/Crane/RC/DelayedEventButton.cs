using System.Collections;
using System.Collections.Generic;
using HTC.UnityPlugin.ColliderEvent;
using UnityEngine;
using UnityEngine.Events;

public class DelayedEventButton : EventButton
{
    [Header("Special: Delay Settings")]
    [Tooltip("Hold duration in seconds to trigger event")]
    public float holdDuration = 2f;

    private Coroutine holdCoroutine;


    public UnityEvent HoldCompleteEvent => ButtonPressedEvent;
    public UnityEvent HoldStartedEvent;
    protected override void Start()
    {
        base.Start();
    }

    public override void OnColliderEventPressEnter(ColliderButtonEventData eventData)
    {
        if (eventData.button == m_activeButton && eventData.clickingHandlers.Contains(gameObject) && pressingEvents.Add(eventData) && pressingEvents.Count == 1)
        {
            HoldStartedEvent?.Invoke();
            holdCoroutine = StartCoroutine(HoldTimer());
        }

    }
    public override void OnColliderEventPressExit(ColliderButtonEventData eventData)
    {

        if (holdCoroutine != null)
        {
            StopCoroutine(holdCoroutine);
            holdCoroutine = null;
        }
        base.OnColliderEventPressExit(eventData);
    }

    private IEnumerator HoldTimer()
    {
        yield return new WaitForSeconds(holdDuration);
        HoldCompleteEvent?.Invoke();
    }
}
