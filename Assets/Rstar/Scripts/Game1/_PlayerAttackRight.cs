using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerAttackRight : _PlayerActionClass
{
    protected override void Action()
    {
        StartCoroutine(Move());
    }

    protected override IEnumerator Move()
    {
        if (parent.showDebug)
        {
            print("attackRight");
        }

        parent.playerHandsAnimator.SetTrigger("attackRightTrigger");

        SkillFinish();

        yield return null;
    }
}
