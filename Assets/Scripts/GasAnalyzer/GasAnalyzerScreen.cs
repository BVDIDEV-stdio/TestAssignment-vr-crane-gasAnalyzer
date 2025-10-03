using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GasAnalyzerScreen : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private float showDuration = .3f;

    [Header("Screens")]
    [SerializeField] private GameObject OnEnableOrDisableObj;
    [SerializeField] private GameObject SafeScreen;
    [SerializeField] private GameObject DangerScreen;
    [SerializeField] private TMP_Text DangerDistanceText; // distance text here

    [Header("Danger Finder")]
    [SerializeField] private DangerFinder dangerFinder; // DangerFinder component carrier here
    [Header("Status: is assigned in runtime")]
    [SerializeField] private bool isEnabled;
    public bool IsEnabled
    {
        get => isEnabled;
        set
        {
            if (showCoroutine != null)
                StopCoroutine(showCoroutine);
            showCoroutine = StartCoroutine(SwitchEnableStatusCoroutine(value));
        }
    }

    public void SwitchEnabledStatus()
    {
        IsEnabled = !IsEnabled;
    }

    private Coroutine showCoroutine;
    private IEnumerator SwitchEnableStatusCoroutine(bool targetValue)
    {
        // show cool intro/outro
        OnEnableOrDisableObj.SetActive(true);
        yield return new WaitForSeconds(showDuration);
        OnEnableOrDisableObj.SetActive(false);

        // after waiting long enough set value
        isEnabled = targetValue;
    }

    private void Update()
    {
        if (dangerFinder == null) return;
        if (!isEnabled) return;

        string distStr = dangerFinder.DistanceToStr;

        if (distStr == "what")
        {
            SafeScreen.SetActive(true);
            DangerScreen.SetActive(false);
        }
        else
        {
            SafeScreen.SetActive(false);
            DangerScreen.SetActive(true);
            if (DangerDistanceText != null)
                DangerDistanceText.text = distStr;
        }
    }
}
