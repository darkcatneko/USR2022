using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemysAnim : MonoBehaviour
{
    [SerializeField] List<Animator> Anims = new List<Animator>();

    public void SetGetHit()
    {
        foreach(Animator anim in Anims)
        {
            anim.SetTrigger("GetHit");
        }
    }

    public void SetDie()
    {
        foreach (Animator anim in Anims)
        {
            anim.SetTrigger("Die");
        }
    }
}
