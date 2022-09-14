using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHittedEffect : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float fadeDuration;


    public void HittedEffect()
    {
        StartCoroutine("UIFade");
    }


    private IEnumerator UIFade()
    {
        canvasGroup.alpha = 1;
        float time = 0;
        while (time < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(1, 0, time / fadeDuration);

            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 0;
    }

}
