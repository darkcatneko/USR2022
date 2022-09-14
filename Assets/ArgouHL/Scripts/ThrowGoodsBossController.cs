using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class ThrowGoodsBossController : MonoBehaviour
{
    [SerializeField] private Animator bossAnimator;
    [SerializeField] private UnityEvent throwGoodsEvents;


    private void Start()
    {
        StartCoroutine("ThrowGoodsLoop");
    }


    public void ThrowGoodsTest(InputAction.CallbackContext context)
    {
        if (context.started)
        {

            ThrowGoods();

        }

    }

    private void ThrowGoods()
    {
        bossAnimator.SetTrigger("ThrowObj");
        throwGoodsEvents.Invoke();
    }


    private IEnumerator ThrowGoodsLoop()
    {
        while(true)
        {

            ThrowGoods();
            yield return new WaitForSeconds(1);


        }
    }    


}
