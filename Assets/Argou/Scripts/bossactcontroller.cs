using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class bossactcontroller : MonoBehaviour
{
    [SerializeField] bossactionclass bossaction;

    // 0= 待機 , 1=攻擊 2=暈,3=後退
    [SerializeField] int bossstage = 0;
    [SerializeField] UnityEvent damagetoplayer;
    



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

//下一個動作(AI的部份)
    public void nextmove()
    {
       
      if(bossstage==0)
        {
            bossaction = gameObject.AddComponent<bossstop>();
            bossstage = 2;
           
        }

        //if (bossstage == 1)
        //{
        //    bossaction = gameObject.AddComponent<>();
        //    bossstage = 2;

        //}

        else if(bossstage == 2)
        {
            //哹叫上給予傷害的function,之後要移動到攻擊裏面
            givedamagetoplayer();


            bossaction = gameObject.AddComponent<bossidle>();
            bossstage = 0;
        }
    }

   


}
