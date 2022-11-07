using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//��q����
public class HpControl : MonoBehaviour
{
    [SerializeField] public int maxHp ;
    [SerializeField] public int nowHp ;
    [SerializeField] private UnityEvent gameEnd;
    


    private void Start()
    {
        nowHp = maxHp;
        
    }

    //�i�H����LUnityEvent�I�s
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
