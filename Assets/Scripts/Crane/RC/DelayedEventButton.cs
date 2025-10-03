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
    protected override void OnButtonPressed()
    {
        //base.OnButtonPressed();
        ApplyButtonOffset();
        HoldStartedEvent?.Invoke();
        holdCoroutine = StartCoroutine(HoldTimer());
    }
    protected override void OnButtonReleased()
    {
        //base.OnButtonReleased();
        ResetButtonPos();
        if (holdCoroutine != null)
        {
            StopCoroutine(holdCoroutine);
            holdCoroutine = null;
        }
    }

    public override void OnColliderEventPressEnter(ColliderButtonEventData eventData)
    {
        if (eventData.button == m_activeButton && eventData.clickingHandlers.Contains(gameObject) && pressingEvents.Add(eventData) && pressingEvents.Count == 1)
        {
            OnButtonPressed();
        }

    }
    public override void OnColliderEventPressExit(ColliderButtonEventData eventData)
    {
        OnButtonReleased();
        base.OnColliderEventPressExit(eventData);
    }

    private IEnumerator HoldTimer()
    {
        yield return new WaitForSeconds(holdDuration);
        HoldCompleteEvent?.Invoke();
    }
}
