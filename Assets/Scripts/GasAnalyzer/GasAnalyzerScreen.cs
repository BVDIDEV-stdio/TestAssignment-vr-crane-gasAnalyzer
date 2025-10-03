using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GasAnalyzerScreen : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private float showDuration = .3f;

    [Header("Screens")]
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private GameObject SafeScreen;
    [SerializeField] private GameObject DangerScreen;
    [SerializeField] private TMP_Text DangerDistanceText; // distance text here

    [Header("Danger Finder")]
    [SerializeField] private DangerFinder dangerFinder; // DangerFinder component carrier here
    [Header("Status: is assigned in runtime")]
    [SerializeField] private bool isEnabled;

    public void SwitchEnabledStatus()
    {
        Debug.Log("kill me");
        if (showCoroutine != null)
            StopCoroutine(showCoroutine);
        showCoroutine = StartCoroutine(SwitchEnableStatusCoroutine(!isEnabled));
    }

    private Coroutine showCoroutine;
    private IEnumerator SwitchEnableStatusCoroutine(bool targetValue)
    {
        // maybe looks like a trick but it's an easy way to suppress UpdateScreen
        isEnabled = false;

            SafeScreen.SetActive(false);
            DangerScreen.SetActive(false);
            LoadingScreen.SetActive(true);

            yield return new WaitForSeconds(showDuration);

            LoadingScreen.SetActive(false);

        isEnabled = targetValue;

        if (!isEnabled)
        {
            SafeScreen.SetActive(false);
            DangerScreen.SetActive(false);
        }
    }

    // update "enabled" states of the screen
    private void UpdateScreen()
    {
        if (dangerFinder == null || !isEnabled) return;

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


    void Start()
    {
        var missing = new List<string>();

        if (DangerScreen == null) missing.Add(nameof(DangerScreen));
        if (SafeScreen == null) missing.Add(nameof(SafeScreen));
        if (LoadingScreen == null) missing.Add(nameof(LoadingScreen));
        if (DangerDistanceText == null) missing.Add(nameof(DangerDistanceText));
        if (dangerFinder == null) missing.Add(nameof(dangerFinder));

        if (missing.Count > 0)
        {
            Debug.LogError("Missing UI components: " + string.Join(", ", missing));
        }
    }

    private void Update()
    {
        if (dangerFinder == null || !isEnabled) return;
        UpdateScreen();
    }

}