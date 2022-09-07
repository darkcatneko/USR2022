using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AttackUISystem : MonoBehaviour
{
    [SerializeField] private Slider attackTimeBar;
    [SerializeField] private Button Button;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private float maxtime;
    [SerializeField] private CanvasGroup attackUI;


    public void startAttackTime()
    {
        StartCoroutine("attackTime");
    }

    IEnumerator attackTime()
    {
        attackUI.blocksRaycasts = true;
        attackUI.alpha = 1;
        attackTimeBar.maxValue = maxtime;
        attackTimeBar.value = maxtime;
        float time =  maxtime;
        timeText.text = time.ToString("0.00");

        while (time> 0)
        {
                       

            time -= Time.deltaTime;
            timeText.text = time.ToString("0.00");
            attackTimeBar.value = time;
            yield return null;
        }

        
        attackUI.blocksRaycasts = false;
        attackUI.alpha = 0;
    }



}
