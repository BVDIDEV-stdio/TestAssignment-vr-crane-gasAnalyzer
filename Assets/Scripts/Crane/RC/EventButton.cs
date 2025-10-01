using HTC.UnityPlugin.ColliderEvent;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class EventButton : MonoBehaviour
                        , IColliderEventClickHandler
                        , IColliderEventPressEnterHandler
                        , IColliderEventPressExitHandler
{
    /// <summary>
    /// To use:
    /// - place the class on an object with a collider comp and a button mesh as a child object
    /// - assign that child button obj to the field "ButtonObj"
    /// - button mesh will be lookin'good if it has MaterialChanger component (better player feedback)
    /// </summary>
    




    [Header("Visuals")]
    public Transform ButtonObj;
    private Vector3 buttonOriginPos;

    [Tooltip("on button press it moves in LOCAL axes by values assigned")]
    public Vector3 buttonDownOffset;


    private HashSet<ColliderButtonEventData> pressingEvents = new HashSet<ColliderButtonEventData>();
    public ColliderButtonEventData.InputButton m_activeButton = ColliderButtonEventData.InputButton.Trigger;

    // Core logic
    [Header("Button State UnityEvents")]
    public UnityEvent ButtonPressedEvent;
    public UnityEvent ButtonReleasedEvent;
    public void OnButtonPressed()
    {
        ButtonPressedEvent?.Invoke();
        ApplyButtonOffset();
    }
    public void OnButtonReleased()
    {
        ButtonReleasedEvent?.Invoke();
        ResetButtonPos();
    }

    // - Visuals & Feedback
    void ApplyButtonOffset() => ButtonObj.localPosition = buttonOriginPos + buttonDownOffset;
    void ResetButtonPos() => ButtonObj.localPosition = buttonOriginPos;

    // -Utilitary

    // Unity lifecycle
    void Start()
    {
        buttonOriginPos = ButtonObj.localPosition;
    }


    // Interfaces
    public void OnColliderEventClick(ColliderButtonEventData eventData)
    {
        if (pressingEvents.Contains(eventData) && pressingEvents.Count == 1)
        {
            
        }
    }
    
    public void OnColliderEventPressEnter(ColliderButtonEventData eventData)
    {
        Debug.Log($"PressEnter: {eventData.button} on {gameObject.name}");
        if (eventData.button == m_activeButton && eventData.clickingHandlers.Contains(gameObject) && pressingEvents.Add(eventData) && pressingEvents.Count == 1)
        {
            OnButtonPressed();
        }
    }

    public void OnColliderEventPressExit(ColliderButtonEventData eventData)
    {
        Debug.Log($"PressExit: {eventData.button} on {gameObject.name}");
        if (pressingEvents.Remove(eventData) && pressingEvents.Count == 0)
        {
            OnButtonReleased();
        }
    }

}
