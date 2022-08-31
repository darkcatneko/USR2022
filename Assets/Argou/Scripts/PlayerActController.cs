using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerActController : MonoBehaviour
{
    [SerializeField] _PlayerActionClass playerAction;

    [SerializeField] private _HpControl hpControl;
    [SerializeField] private UnityEvent damageToBoss;
    [SerializeField] public Animator playerHandsAnimator;
    [SerializeField] private BossActController bossActController;

    public bool isDefenceing;

    public void DefenceAndattack()
    {
        if (bossActController.isStunned)
        {
            damageToBoss.Invoke();
        }
        else
        {
            isDefenceing = true;
        }
        
    }




    //�����ˮ`(�z�LUnityEvent�h�ϥΪ��aobj�W���ˮ`funtion)
    public void GiveDamageToBoss()
    {
        damageToBoss.Invoke();
    }

    public void DefenceUp()
    {
        if (!TryGetComponent<_PlayerDefenceUp>(out var _playerDefenceUp) && !TryGetComponent<_PlayerDefenceDown>(out var _PlayerDefenceDown)) 
        {
            playerAction = gameObject.AddComponent<_PlayerDefenceUp>();
        }
    }
    public void DefenceDown()
    {
        playerAction = gameObject.AddComponent<_PlayerDefenceDown>();
    }



}
