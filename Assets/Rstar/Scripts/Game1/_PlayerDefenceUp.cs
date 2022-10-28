using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerDefenceUp : PlayerActionClass
{
    float defenceTime = .5f;

    protected override void Action()
    {
        StartCoroutine(Move());
    }

    protected override IEnumerator Move()
    {
        if (parent.showDebug)
        {
            print("up");
        }

        float duration = defenceTime;

        parent.isDefenceing = true;
        parent.playerHandsAnimator.SetTrigger("handsUpTrigger");
        parent.playerHandsAnimator.SetLayerWeight(parent.playerHandsAnimator.GetLayerIndex("Guard Layer"), 1f);

        yield return new WaitForSeconds(defenceTime);

        parent.DefenceDown();
        SkillFinish();
    }
}
