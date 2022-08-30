using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class BossActController : MonoBehaviour
{
    [SerializeField] BossActionClass bossAction;

    // 0= 待機 , 1=攻擊 2=後退,3=暈
    [SerializeField] private int bossStage = 0;
    [SerializeField] private int nextBossStage = 1;
    [SerializeField] bool tapHintsShow;
    [SerializeField] CanvasGroup tapHints;
    [SerializeField] private HpControl hpControl;
    [SerializeField] private UnityEvent damagetoplayer;







    //給予傷害(透過UnityEvent去使用玩家obj上的傷害funtion)
    public void givedamagetoplayer()
    {
        damagetoplayer.Invoke();
    }


    //第一個動作
    private void Start()
    {
        bossAction = gameObject.AddComponent<BossIdle>();
        
    }

    //下一個動作(AI的部份)(目前是待機>攻擊>暈眩>待機>...)
    public void nextmove()
    {
        if (nextBossStage == 0)
        {
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
        if (bossStage == 1)
        {
            taphint(0);
            bossAction.stopattack();
            nextBossStage = 3;
            nextmove();
            hpControl.getdamage(1);
        }

    }


    public void taphint(int x)
    {

        if (tapHintsShow)
        {
            tapHints.alpha = x;
        }

    }



}
