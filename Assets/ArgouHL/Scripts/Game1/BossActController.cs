using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class BossActController : MonoBehaviour
{
    [SerializeField] public BoxerBossParticleControl boxerBossParticleControl;
    [SerializeField] public BossActionClass bossAction;
    [SerializeField] public Animator animator;
    // 0= 待機 , 1=攻擊 2=後退,3=暈
    [SerializeField] public int bossStage = 0;
    [SerializeField] private int nextBossStage = 1;

    [SerializeField] bool tapHintsShow = true;
    [SerializeField] CanvasGroup tapHints;
    [SerializeField] private TMP_Text hints;
    [SerializeField] private HpControl hpControl;
    [SerializeField] private UnityEvent damageToPlayer;
    [SerializeField] private UnityEvent guardSuccessed;

    [SerializeField] private UnityEvent attackTimeUIShow;
    [SerializeField] private UnityEvent attackTimeUIDisapper;

    [SerializeField] private Button attackButton;
    [SerializeField] private UnityEvent guard;
    [SerializeField] private PlayerActController playerActController;
    [SerializeField] private BoxerGameControl boxerGameControl;


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

    [SerializeField] private int attackedTimes = 0;
    [SerializeField] private int blockedTimes = 0;
    [SerializeField] private int gettedDamage = 0;

    [SerializeField] private int maxGetDamage;
    [SerializeField] private int blockTimesBeforeStun;
    [SerializeField] private int attackTimesBeforeBack;

    public int canAttackTime;

    private int hitPlayerCount = 0;
    public float attackFactor = 1;

    [SerializeField] private Material bossNormal;
    [SerializeField] private Material bossStun;
    [SerializeField] private SkinnedMeshRenderer bossMeshRender;

    private void Start()
    {
        maxGetDamage = maxGetdamage_1;
        blockTimesBeforeStun = blockTimes_1;
        canAttackTime = canAttacktime_1;
        attackTimesBeforeBack = attackTimes_1;

        //第一個動作

    }

    private void Update()
    {
        if (gettedDamage >= maxGetDamage)
        {
            gettedDamage = 0;
            StopStunned();

        }
    }

    public void FirstCombo()
    {
        bossAction = gameObject.AddComponent<BossIdle>();
    }


    //給予傷害(透過UnityEvent去使用玩家obj上的傷害funtion)
    public void GiveDamageToPlayer()
    {

        if (playerActController.isDefenceing)
        {
            guardSuccessed.Invoke();
            blockedTimes++;
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
            attackedTimes++;
            hitPlayerCount++;
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
        //guardDetermindUIDisapper.Invoke();
    }

    public void AttackAgain()
    {

        print("attackagain");

        bossStage = nextBossStage;
        nextBossStage = 1;

        if (BoxerGameControl.gameEnd)
        {
            nextBossStage = 0;
        }
        bossAction = gameObject.AddComponent<BossTestBackward>();
    }


    //下一個動作(AI的部份)(目前是待機>攻擊>暈眩>待機>...)
    public void NextMove()
    {
        NextStage();
        if (BoxerGameControl.gameEnd && bossStage == 0 || BoxerGameControl.gameEnd && bossStage == 3)
            return;
        if (nextBossStage == 0)//待機
        {
            attackedTimes = 0;
            blockedTimes = 0;
            bossStage = nextBossStage;
            nextBossStage = 1;
            bossAction = gameObject.AddComponent<BossIdle>();
        }
        else if (nextBossStage == 1)//攻擊
        {
            attackFactor = Mathf.Abs(attackFactor - 1);
            animator.SetFloat("AtkMod", attackFactor);
            
            //guardDetermindUIShow.Invoke();
            bossStage = nextBossStage;
            nextBossStage = 2;
            bossAction = gameObject.AddComponent<BossTestAttack>();
            
        }
        else if (nextBossStage == 2)//後退
        {
            gettedDamage = 0;
            bossStage = nextBossStage;
            nextBossStage = 0;
            boxerBossParticleControl.StopStun();
            bossMeshRender.material = bossNormal;
            bossAction = gameObject.AddComponent<BossTestBackward>();
        }
        else if (nextBossStage == 3)//暈
        {

            attackTimeUIShow.Invoke();
            bossStage = nextBossStage;
            nextBossStage = 2;
            bossAction = gameObject.AddComponent<BossStop>();
        }
        else if (nextBossStage == 4)//
        {
            bossStage = nextBossStage;
            bossAction = gameObject.AddComponent<BossStop>();
        }
    }

    //被反擊暈眩後
    public void Stunned()
    {
        bossMeshRender.material = bossStun;
        boxerBossParticleControl.Stun();
        isStunned = true;
        TapHint(1, "Tap to Attack");
        nextBossStage = 3;
        NextMove();
        blockedTimes = 0;

    }

    public void TapHint(int x, string hintsText)
    {

        if (tapHintsShow)
        {
            tapHints.alpha = x;
            hints.text = hintsText;
        }

    }

    public void StopStunned()
    {
        if (BoxerGameControl.gameEnd)
            return;

       
        attackTimeUIDisapper.Invoke();
        TapHint(0, "");
        isStunned = false;
        bossAction.StopAttack();
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

    public void GetDamage(int damage)
    {
        animator.SetTrigger("hit");
        boxerBossParticleControl.GetHit();
        gettedDamage += damage;

        if (gettedDamage >= maxGetDamage)
        {
            hpControl.getDamage(maxGetDamage - (gettedDamage - damage));
            gettedDamage = 0;
            StopStunned();

        }
        else
        {
            hpControl.getDamage(damage);
        }


    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (BoxerGameControl.gameEnd)
            return;

        if (context.started)//MouseDown
        {


            if (bossStage == 1)
            {
                guard.Invoke();
                Debug.Log("guard");

            }
            else if (bossStage == 3)
            {

                attackButton.onClick.Invoke();
                SimulateClick(attackButton);
                Debug.Log("Atk");
            }
        }

    }

    public static void SimulateClick(Button button)
    {
        ExecuteEvents.Execute(button.gameObject, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);
    }

    public void BossDead()
    {
        animator.SetTrigger("dead");
    }


    public int GetHitPlayerCount()
    {
        return hitPlayerCount;
    }


}
