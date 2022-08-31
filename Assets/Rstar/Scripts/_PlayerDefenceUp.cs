using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerDefenceUp : _PlayerActionClass
{
    float defenceTime = .5f;

    protected override void Action()
    {
        StartCoroutine(Move());
    }

    protected override IEnumerator Move()
    {
        print("defence");

        float duration = defenceTime;

        parent.isDefenceing = true;
        parent.playerHandsAnimator.SetTrigger("handsUpTrigger");

        yield return new WaitForSeconds(defenceTime);

        parent.DefenceDown();
        SkillFinish();
    }
}
