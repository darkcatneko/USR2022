using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class BossActController : MonoBehaviour
{
    [SerializeField] BossActionClass bossAction;
    [SerializeField] public Animator animator;
    // 0= 待機 , 1=攻擊 2=後退,3=暈
    [SerializeField] private int bossStage = 0;
    [SerializeField] private int nextBossStage = 1;
    [SerializeField] bool tapHintsShow;
    [SerializeField] CanvasGroup tapHints;
    [SerializeField] private HpControl hpControl;
    [SerializeField] private UnityEvent damageToPlayer;
    [SerializeField] private PlayerActController playerActController;

    [Header("Boss Stage Setting")]
    [SerializeField] private int blockTimes_1;
    [SerializeField] private int maxGetdamage_1;
    [SerializeField] private int canAttacktime_1;
    [SerializeField] private int hpTostage2;
    [SerializeField] private int blockTimes_2;
    [SerializeField] private int maxGetdamage_2;
    [SerializeField] private int canAttacktime_2;
    [SerializeField] private int hpTostage3;
    [SerializeField] private int blockTimes_3;
    [SerializeField] private int maxGetdamage_3;
    [SerializeField] private int canAttacktime_3;

    public bool isStunned = false;

    private int blockedTimes = 0;
    [SerializeField] private int getteddamage = 0;

    [SerializeField] private int maxGetdamag;
    [SerializeField] private int blockTimesBeforeStun;
    public int canAttacktime;


    private void Start()
    {
        maxGetdamag = maxGetdamage_1;
        blockTimesBeforeStun = blockTimes_1;
        canAttacktime = canAttacktime_1;

        //第一個動作
        bossAction = gameObject.AddComponent<BossIdle>();

        

    }



    private void Update()
    {
        if (getteddamage >= maxGetdamag)
        {
            getteddamage = 0;
            stopstunned();

        }
    }



    //給予傷害(透過UnityEvent去使用玩家obj上的傷害funtion)
    public void givedamagetoplayer()
    {
        if (playerActController.isDefenceing)
        {
            blockedTimes += 1;
            playerActController.isDefenceing = false;
            if (blockedTimes >= blockTimesBeforeStun)
            {

                stunned();

            }
            else
            {
                nextBossStage = 2;

            }
        }
        else
        {
            damageToPlayer.Invoke();
            nextmove();
        }


    }




    //下一個動作(AI的部份)(目前是待機>攻擊>暈眩>待機>...)
    public void nextmove()
    {
        nextstage();


        if (nextBossStage == 0)
        {
            blockedTimes = 0;
            bossStage = nextBossStage;
            nextBossStage = 1;
            bossAction = gameObject.AddComponent<BossIdle>();

        }
        else if (nextBossStage == 1)
        {
            bossStage = nextBossStage;
            nextBossStage = 2;
            bossAction = gameObject.AddComponent<BossTestAttack>();

        }

        else if (nextBossStage == 2)
        {
            getteddamage = 0;
            bossStage = nextBossStage;
            nextBossStage = 0;

            bossAction = gameObject.AddComponent<BossTestBackward>();

        }

        else if (nextBossStage == 3)
        {
            bossStage = nextBossStage;
            nextBossStage = 2;

            bossAction = gameObject.AddComponent<BossStop>();

        }




    }

    //被反擊暈眩後
    public void stunned()
    {
        isStunned = true;
        taphint(0);
        nextBossStage = 3;
        nextmove();

       



    }


    public void taphint(int x)
    {

        if (tapHintsShow)
        {
            tapHints.alpha = x;
        }

    }


    public void stopstunned()
    {

        isStunned = false;
        bossAction.stop();
        nextBossStage = 2;
        nextmove();

    }

    public void nextstage()
    {
        if (hpControl.nowHp <= hpTostage3)
        {
            maxGetdamag = maxGetdamage_3;
            blockTimesBeforeStun = blockTimes_3;
            canAttacktime = canAttacktime_3;

        }
        else if (hpControl.nowHp <= hpTostage2)
        {
            maxGetdamag = maxGetdamage_2;
            blockTimesBeforeStun = blockTimes_2;
            canAttacktime = canAttacktime_2;

        }

    }

    public void getDamageCount(int x)
    {
        getteddamage += x;
    }



}
