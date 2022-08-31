using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerAttackLeft : _PlayerActionClass
{
    protected override void Action()
    {
        StartCoroutine(Move());
    }

    protected override IEnumerator Move()
    {
        print("attackLeft");

        parent.playerHandsAnimator.SetTrigger("attackLeftTrigger");

        SkillFinish();

        yield return null;
    }
}
