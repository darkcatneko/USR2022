using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefenceDown : PlayerActionClass
{
    float downTime = .5f;

    protected override void Action()
    {
        StartCoroutine(Move());
    }

    protected override IEnumerator Move()
    {
        if (parent.showDebug)
        {
            print("down");
        }

        float duration = downTime;

        parent.isDefenceing = false;
        parent.playerHandsAnimator.SetTrigger("handsDownTrigger");

        yield return new WaitForSeconds(downTime);

        SkillFinish();
    }
}
