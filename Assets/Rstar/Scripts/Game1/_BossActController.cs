using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class _BossActController : MonoBehaviour
{
    [SerializeField] _BossActionClass bossAction;
    [SerializeField] public Animator animator;
    // 0= 待機 , 1=攻擊 2=後退,3=暈
    [SerializeField] public int bossStage = 0;
    [SerializeField] private int nextBossStage = 1;
    [SerializeField] bool tapHintsShow;
    [SerializeField] CanvasGroup tapHints;
    [SerializeField] private _HpControl hpControl;
    [SerializeField] private UnityEvent damageToPlayer;
    [SerializeField] private _PlayerActController playerActController;

    [Header("Boss Stage Setting")]
    [SerializeField] private int attackTimes_1;
    [SerializeField] private int blockTimes_1;
    [SerializeField] private int maxGetdamage_1;
    [SerializeField] private int canAttacktime_1;
    [SerializeField] private int hpTostage2;
    [SerializeField] private int attackTimes_2;
    [SerializeField] private int blockTimes_2;
    [SerializeField] private int maxGetdamage_2;
    [SerializeField] private int canAttacktime_2;
    [SerializeField] private int hpTostage3;
    [SerializeField] private int attackTimes_3;
    [SerializeField] private int blockTimes_3;
    [SerializeField] private int maxGetdamage_3;
    [SerializeField] private int canAttacktime_3;

    public bool isStunned = false;

    private int attackedTimes = 0;
    private int blockedTimes = 0;
    [SerializeField] private int gettedDamage = 0;

    [SerializeField] private int maxGetDamage;
    [SerializeField] private int blockTimesBeforeStun;
    [SerializeField] private int attackTimesBeforeBack;
    public int canAttackTime;


    private void Start()
    {
        maxGetDamage = maxGetdamage_1;
        blockTimesBeforeStun = blockTimes_1;
        canAttackTime = canAttacktime_1;
        attackTimesBeforeBack = attackTimes_1;

        //第一個動作
        bossAction = gameObject.AddComponent<_BossIdle>();
    }

    private void Update()
    {
        if (gettedDamage >= maxGetDamage)
        {
            gettedDamage = 0;
            StopStunned();

        }
    }

    //給予傷害(透過UnityEvent去使用玩家obj上的傷害funtion)
    public void GiveDamageToPlayer()
    {
        if (playerActController.isDefenceing)
        {
            blockedTimes += 1;
            playerActController.DefenceDown();

            if (blockedTimes >= blockTimesBeforeStun)
            {
                Stunned();
            }
            else
            {
                AttackAgain();
            }
        }
        else
        {
            attackedTimes += 1;
            damageToPlayer.Invoke();

            if (attackedTimes >= attackTimesBeforeBack) 
            {
                NextMove();
            }
            else
            { 
                AttackAgain(); 
            }
        }
    }

    private void AttackAgain()
    {
        nextBossStage = 1;
        bossAction = gameObject.AddComponent<_BossTestBackWard>();
    }


    //下一個動作(AI的部份)(目前是待機>攻擊>暈眩>待機>...)
    public void NextMove()
    {
        NextStage();

        if (nextBossStage == 0)
        {
            attackedTimes = 0;
            blockedTimes = 0;
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
            gettedDamage = 0;
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
        isStunned = true;
        TapHint(0);
        nextBossStage = 3;
        NextMove();
    }

    public void TapHint(int x)
    {
        if (tapHintsShow)
        {
            tapHints.alpha = x;   
        }
    }

    public void StopStunned()
    {
        isStunned = false;
        bossAction.Stop();
        nextBossStage = 2;
        NextMove();
    }

    public void NextStage()
    {
        if (hpControl.nowHp <= hpTostage3)
        {
            maxGetDamage = maxGetdamage_3;
            blockTimesBeforeStun = blockTimes_3;
            canAttackTime = canAttacktime_3;
            attackTimesBeforeBack = attackTimes_3;
        }
        else if (hpControl.nowHp <= hpTostage2)
        {
            maxGetDamage = maxGetdamage_2;
            blockTimesBeforeStun = blockTimes_2;
            canAttackTime = canAttacktime_2;
            attackTimesBeforeBack = attackTimes_2;
        }
         
    }

    public void GetDamageCount(int x)
    {
        gettedDamage += x;
    }

}
