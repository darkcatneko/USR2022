using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class _PlayerActController : MonoBehaviour
{
    [SerializeField] _PlayerActionClass playerAction;
    [SerializeField] _BossActController bossAct;

    [SerializeField] private _HpControl hpControl;
    [SerializeField] private UnityEvent damageToBoss;
    [SerializeField] public Animator playerHandsAnimator;

    public bool isDefenceing;
    bool isLeftOraOra;

    public bool showDebug = false;

    //給予傷害(透過UnityEvent去使用玩家obj上的傷害funtion)
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
        if (TryGetComponent<_PlayerDefenceUp>(out var _playerDefenceUp)) 
        {
            _playerDefenceUp.SkillFinish();
        }
        playerAction = gameObject.AddComponent<_PlayerDefenceDown>();
    }
    public void Attack()
    {
        if (isLeftOraOra)
        {
            playerAction = gameObject.AddComponent<_PlayerAttackLeft>();
            isLeftOraOra = false;
        }
        else
        {
            playerAction = gameObject.AddComponent<_PlayerAttackRight>();
            isLeftOraOra = true;
        }
    }

    //左鍵執行
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.started)//MouseDown
        {
            if (bossAct.bossStage == 0 || bossAct.bossStage == 1 || bossAct.bossStage == 2)
            {
                DefenceUp();
            }
            else if (bossAct.bossStage == 3 || bossAct.bossStage == 4/*測試攻擊*/)
            {
                GiveDamageToBoss();
                Attack();
            }
        }
        
    }

}
