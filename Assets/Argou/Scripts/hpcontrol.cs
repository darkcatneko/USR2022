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
    


    private void Start()
    {
        nowHp = maxHp;
        
    }

    //�i�H����LUnityEvent�I�s
    public void getdamage(int x)
    {
        nowHp -= x;
        
    }

   


}
