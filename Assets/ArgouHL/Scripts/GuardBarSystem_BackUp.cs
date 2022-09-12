using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class GuardBarSystem_BackUp : MonoBehaviour
{
    [SerializeField] private AttackUISystem attackUISystem;
    [SerializeField] private CanvasGroup GuardUI;
    [SerializeField] private GameObject deterBar;
    [SerializeField] private float readytime =0.5f;
    [SerializeField] private float gettime=0.5f;
    [SerializeField] TMP_Text hints;
    private RectTransform Rect;
    private Vector2 rectPos;
    bool isGuardsuccessd= false;

    // Start is called before the first frame update
    void Start()
    {
        Rect = deterBar.GetComponent<RectTransform>();
        rectPos = Rect.anchoredPosition;
        startGuardDeter();
    }

 

    public void guarded()
    {
        StopCoroutine("guardDetermine");
        if(isGuardsuccessd)
        {
            hints.text = "Success";
            GuardUI.alpha = 0;
            attackUISystem.startAttackTime();
        }
        else
        {
            hints.text = "Fail";
            guardUIFade();
        }

    }

    private void startGuardDeter()
    {
        StartCoroutine("guardDetermine");
    }

    IEnumerator guardUIFade()
    {
        yield return new WaitForSeconds(1f);
        GuardUI.alpha = 0;
    }


    private IEnumerator guardDetermine()
    {
        GuardUI.alpha = 1;
        GuardUI.blocksRaycasts = true;
        hints.text = "Tap to Guard!!!";
        yield return new WaitForSeconds(0.4f);
        
        float time = 0;
        isGuardsuccessd = false;
        while (time < readytime)
        {
            print(rectPos);
           rectPos.x = Mathf.Lerp(-600f, 600f, time / (readytime + gettime));
            Rect.anchoredPosition = rectPos;
            time += Time.deltaTime;
            yield return null;
        }

        isGuardsuccessd = true;
        while (time < (readytime+ gettime))
        {
            print(rectPos);
            rectPos.x = Mathf.Lerp(-600f, 600f, time / (readytime + gettime));
            Rect.anchoredPosition = rectPos;
            time += Time.deltaTime;
            yield return null;
        }
        hints.text = "Fail";
        yield return new WaitForSeconds(2f);
        GuardUI.blocksRaycasts = false;
        GuardUI.alpha = 0;
     }


  

}
