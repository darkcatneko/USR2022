using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerActController : MonoBehaviour
{
    [SerializeField] PlayerActionClass playerAction;
    [SerializeField] BossActController bossAct;

    [SerializeField] private HpControl hpControl;
    [SerializeField] private UnityEvent damageToBoss;
    [SerializeField] public Animator playerHandsAnimator;

    public bool isDefenceing;
    bool isLeftOraOra;

    public bool showDebug = false;

    //�����ˮ`(�z�LUnityEvent�h�ϥΪ��aobj�W���ˮ`funtion)
    public void GiveDamageToBoss()
    {
        damageToBoss.Invoke();
    }

    public void DefenceUp()
    {
        if (!TryGetComponent<PlayerDefenceUp>(out var playerDefenceUp) && !TryGetComponent<PlayerDefenceDown>(out var PlayerDefenceDown)) 
        {
            playerAction = gameObject.AddComponent<PlayerDefenceUp>();
        }
    }
    public void DefenceDown()
    {
        if (TryGetComponent<PlayerDefenceUp>(out var playerDefenceUp)) 
        {
            playerDefenceUp.SkillFinish();
        }
        playerAction = gameObject.AddComponent<PlayerDefenceDown>();
    }
    public void Attack()
    {
        if (isLeftOraOra)
        {
            playerAction = gameObject.AddComponent<PlayerAttackLeft>();
            isLeftOraOra = false;
        }
        else
        {
            playerAction = gameObject.AddComponent<PlayerAttackRight>();
            isLeftOraOra = true;
        }
    }

    //�������
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.started)//MouseDown
        {
            if (bossAct.bossStage == 0 || bossAct.bossStage == 1 || bossAct.bossStage == 2)
            {
                DefenceUp();
            }
            else if (bossAct.bossStage == 3 || bossAct.bossStage == 4/*���է���*/)
            {
                GiveDamageToBoss();
                Attack();
            }
        }
        
    }

}
