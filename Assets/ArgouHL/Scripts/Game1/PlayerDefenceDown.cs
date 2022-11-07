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
        Animator animator = parent.playerHandsAnimator;
        animator.SetTrigger("handsDownTrigger");


        int layer = animator.GetLayerIndex("Guard Layer");
        while (true)
        {
            if (animator.GetCurrentAnimatorClipInfo(layer)[0].clip.name == "hand_down_2" && animator.GetCurrentAnimatorStateInfo(layer).normalizedTime >= 1)
            {
                Debug.Log(animator.GetCurrentAnimatorClipInfo(layer)[0].clip.length);
                duration -= animator.GetCurrentAnimatorClipInfo(layer)[0].clip.length;

                animator.SetLayerWeight(layer, 0f);
                break;
            }
            yield return null;
        }

        yield return new WaitForSeconds(duration);

        SkillFinish();
    }
}
