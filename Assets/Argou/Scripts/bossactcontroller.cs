using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class bossactcontroller : MonoBehaviour
{
    [SerializeField] bossactionclass bossaction;

    // 0= 待機 , 1=攻擊 2=後退,3=暈
    [SerializeField] private int bossstage = 0;
    [SerializeField] private int nextbossstage = 2;
    [SerializeField] bool Taphintsshow;
    [SerializeField] CanvasGroup taphints;

    [SerializeField] private UnityEvent damagetoplayer;
    






    //給予傷害(透過UnityEvent去使用玩家obj上的傷害funtion)
    public void givedamagetoplayer()
    {
        damagetoplayer.Invoke();
    }


    //第一個動作
    private void Start()
    {
        bossaction = gameObject.AddComponent<bossidle>();
    }

    //下一個動作(AI的部份)(目前是待機>攻擊>暈眩>待機>...)
    public void nextmove()
    {
        if (nextbossstage == 0)
        {



            bossstage = nextbossstage;
            nextbossstage = 1;
            bossaction = gameObject.AddComponent<bossidle>();

        }
        else if (nextbossstage == 1)
        {


            bossstage = nextbossstage;
            nextbossstage = 2;
            bossaction = gameObject.AddComponent<bosstestattack>();

        }

        else if (nextbossstage == 2)
        {
            bossstage = nextbossstage;
            nextbossstage = 0;

            bossaction = gameObject.AddComponent<bosstebackward>();

        }

        else if(nextbossstage == 3)
        {
            bossstage = nextbossstage;
            nextbossstage = 2;

            bossaction = gameObject.AddComponent<bossstop>();

        }
        


        
    }

    //被反擊暈眩後
    public void stunned()
    {
        if (bossstage == 1)
        {
            taphint(0);
            bossaction.stopattack();
            nextbossstage = 3;
            nextmove();
        }
        
    }


    public void taphint(int x)
    {

    if (Taphintsshow)
        {
            taphints.alpha = x;   
        }

    }

    

}
