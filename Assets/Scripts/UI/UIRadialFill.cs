using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRadialFill : MonoBehaviour
{
    [SerializeField] private Image radialImage; 

    private Coroutine fillCoroutine;

    public void StartFilling(float duration)
    {
        if (fillCoroutine != null)
            StopCoroutine(fillCoroutine);
        fillCoroutine = StartCoroutine(FillOverTime(duration));
    }

    public void StopFilling()
    {
        if (fillCoroutine != null)
        {
            StopCoroutine(fillCoroutine);
            fillCoroutine = null;
        }
        radialImage.fillAmount = 0f;
    }

    private IEnumerator FillOverTime(float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            radialImage.fillAmount = Mathf.Clamp01(elapsed / duration);
            yield return null;
        }
        radialImage.fillAmount = 1f;
    }
}
