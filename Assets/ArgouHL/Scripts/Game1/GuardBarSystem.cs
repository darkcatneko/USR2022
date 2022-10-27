using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class GuardBarSystem : MonoBehaviour
{
    
    [SerializeField] private CanvasGroup GuardUI;
    [SerializeField] private GameObject deterBar;
    [SerializeField] private BossActController bossActController;


   
    
    private RectTransform Rect;
    private Vector2 rectPos;
    bool isGuardsuccessd= false;

    

    // Start is called before the first frame update
    void Start()
    {
        Rect = deterBar.GetComponent<RectTransform>();
        rectPos = Rect.anchoredPosition;
        
    }

 

    public void guarded()
    {
        StopCoroutine("guardDetermine");
       
    }

    public void startGuardDeter()
    {
        StartCoroutine("guardDetermine");
    }

    public void guardUIFade()
    {
        
        
        GuardUI.alpha = 0; 
        
       
    }


    private IEnumerator guardDetermine()
    {
        
        float readytime = bossActController.bossAction.attackReadyTime;
        float gettime = bossActController.bossAction.attackTime;


        GuardUI.alpha = 1;
        
        //hints.text = "Tap to Guard!!!";
        
        
        float time = 0;
        isGuardsuccessd = false;
        while (time < bossActController.bossAction.attackReadyTime)
        {
            print(rectPos);
           rectPos.x = Mathf.Lerp(-600f, 600f, time / (bossActController.bossAction.attackReadyTime + gettime));
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
        isGuardsuccessd = false;
        
        yield return new WaitForSeconds(0.4f);
        guardUIFade();
       
     }


  

}
