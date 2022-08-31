using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerDefenceDown : _PlayerActionClass
{
    float downTime = .5f;

    protected override void Action()
    {
        StartCoroutine(Move());
    }

    protected override IEnumerator Move()
    {
        print("down");

        float duration = downTime;

        parent.isDefenceing = false;
        parent.playerHandsAnimator.SetTrigger("handsDownTrigger");

        yield return new WaitForSeconds(downTime);

        SkillFinish();
    }
}
