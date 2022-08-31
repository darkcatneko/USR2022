using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class _BossActController : MonoBehaviour
{
    [SerializeField] _BossActionClass bossAction;

    // 0= 待機 , 1=攻擊 2=後退,3=暈
    [SerializeField] public int bossStage = 0;
    [SerializeField] private int nextBossStage = 2;
    [SerializeField] bool tapHintsShow;
    [SerializeField] CanvasGroup tapHints;
    [SerializeField] private _HpControl hpControl;
    [SerializeField] private UnityEvent damageToPlayer;
    

    //給予傷害(透過UnityEvent去使用玩家obj上的傷害funtion)
    public void GiveDamageToPlayer()
    {
        damageToPlayer.Invoke();
    }


    //第一個動作
    private void Start()
    {
        bossAction = gameObject.AddComponent<_BossIdle>();
    }

    //下一個動作(AI的部份)(目前是待機>攻擊>暈眩>待機>...)
    public void NextMove()
    {
        if (nextBossStage == 0)
        {
            bossStage = nextBossStage;
            nextBossStage = 1;
            bossAction = gameObject.AddComponent<_BossIdle>();

        }
        else if (nextBossStage == 1)
        {
            bossStage = nextBossStage;
            nextBossStage = 2;
            bossAction = gameObject.AddComponent<_BossTestAttack>();

        }
        else if (nextBossStage == 2)
        {
            bossStage = nextBossStage;
            nextBossStage = 0;
            bossAction = gameObject.AddComponent<_BossTestBackWard>();

        }
        else if(nextBossStage == 3)
        {
            bossStage = nextBossStage;
            nextBossStage = 2;
            bossAction = gameObject.AddComponent<_BossStop>();
        }
        else if (nextBossStage == 4)//測試攻擊
        {
            bossStage = nextBossStage;
            bossAction = gameObject.AddComponent<_BossStop>();
        }
    }

    //被反擊暈眩後
    public void Stunned()
    {
        if (bossStage == 1)
        {
            TapHint(0);
            bossAction.StopAttack();
            nextBossStage = 3;
            NextMove();
            hpControl.GetDamage(1);
        }
        
    }


    public void TapHint(int x)
    {
        if (tapHintsShow)
        {
            tapHints.alpha = x;   
        }
    }

}
