using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class ThrowGoodsBossController : MonoBehaviour
{
    [SerializeField] private Animator bossAnimator;
    [SerializeField] private UnityEvent throwGoodsEvents;
    [SerializeField] public float minNextThrowTime;
    public float nextThrowTime;

    private void Start()
    {
        nextThrowTime = minNextThrowTime;
        StartCoroutine("ThrowGoodsLoop");
    }



    private void ThrowGoods()
    {
        bossAnimator.SetTrigger("ThrowObj");
        throwGoodsEvents.Invoke();
    }


    private IEnumerator ThrowGoodsLoop()
    {
        while (true)
        {
            print(nextThrowTime);
            yield return new WaitForSeconds(nextThrowTime);
            ThrowGoods();
        }
    }





}
