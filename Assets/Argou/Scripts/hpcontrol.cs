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
    


    private void Start()
    {
        nowHp = maxHp;
        
    }

    //可以給其他UnityEvent呼叫
    public void getdamage(int x)
    {
        nowHp -= x;
        
    }

   


}
