using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _HandAnimatorFunction : MonoBehaviour
{
    public void HandIdle()
    {
        GetComponent<Animator>().SetTrigger("idle");
    }
}
