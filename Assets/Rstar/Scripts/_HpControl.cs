using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//��q����
public class _HpControl : MonoBehaviour
{
    [SerializeField] private int maxHp;
    [SerializeField] protected int nowHp;
    [SerializeField] CanvasGroup hpBar;
    

    private void Start()
    {
        nowHp = maxHp;
    }

    //�i�H����LUnityEvent�I�s
    public void GetDamage(int x)
    {
        nowHp -= x;
    }


}
