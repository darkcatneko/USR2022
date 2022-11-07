using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//血量控制
public class HpControl : MonoBehaviour
{
    [SerializeField] public int maxHp ;
    [SerializeField] public int nowHp ;
    [SerializeField] private UnityEvent gameEnd;
    


    private void Start()
    {
        nowHp = maxHp;
        
    }

    //可以給其他UnityEvent呼叫
    public void getDamage(int x)
    {
        if (BoxerGameControl.gameEnd)
            return;
        nowHp -= x;
        
        if(nowHp<=0)
        {
            
            
            gameEnd.Invoke();

        }
    }

   


}
