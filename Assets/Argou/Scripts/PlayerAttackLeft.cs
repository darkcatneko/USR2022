using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackLeft : PlayerActionClass
{
    protected override void Action()
    {
        StartCoroutine(Move());
    }

    protected override IEnumerator Move()
    {
        if (parent.showDebug)
        {
            print("attackLeft");
        }

        parent.playerHandsAnimator.SetTrigger("attackLeftTrigger");

        SkillFinish();

        yield return null;
    }
}
