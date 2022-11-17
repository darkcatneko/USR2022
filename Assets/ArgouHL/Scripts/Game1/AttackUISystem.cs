using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AttackUISystem : MonoBehaviour
{
    [SerializeField] private CanvasGroup attackUI;
    [SerializeField] private BossActController bossActController;


    public void startAttackTime()
    {
        StartCoroutine("attackTime");
    }

    public void stopAttackTime()
    {
        StopCoroutine("attackTime");
        
        attackUI.alpha = 0;
        
    }

    IEnumerator attackTime()
    {
        float time = bossActController.canAttackTime;

        attackUI.alpha = 1;

        while (time> 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }
        
        attackUI.alpha = 0;
    }

}
