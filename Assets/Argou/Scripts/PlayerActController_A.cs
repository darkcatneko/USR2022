using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerActController_A : MonoBehaviour
{
    [SerializeField] PlayerActionClass playerAction;

    [SerializeField] private HpControl hpControl;
    [SerializeField] private UnityEvent damageToBoss;
    [SerializeField] public Animator playerHandsAnimator;
    [SerializeField] private BossActController bossAct;
    

    public bool isDefenceing;

    




    //給予傷害(透過UnityEvent去使用玩家obj上的傷害funtion)
    public void GiveDamageToBoss()
    {
        damageToBoss.Invoke();
    }

    public void DefenceUp()
    {
        if (!TryGetComponent<PlayerDefenceUp>(out var _playerDefenceUp) && !TryGetComponent<PlayerDefenceDown>(out var _PlayerDefenceDown)) 
        {
            playerAction = gameObject.AddComponent<PlayerDefenceUp>();
        }
    }
    public void DefenceDown()
    {
        playerAction = gameObject.AddComponent<PlayerDefenceDown>();
    }



    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.started)//MouseDown
        {
            if (bossAct.bossStage == 0 || bossAct.bossStage == 1 || bossAct.bossStage == 2)
            {
                isDefenceing = true;
            }
            else if (bossAct.isStunned)
            {
                damageToBoss.Invoke();
            }
        }

    }

}
