using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxerGameControl    : MonoBehaviour
{
    [SerializeField] private UnityEvent win;
    [SerializeField] private UnityEvent lose;
    [SerializeField] private WinLoseUIControl winLoseUIControl;
    [SerializeField] private BossActController bossActController ;

    public static bool gameEnd = false;

    private void Awake()
    {
        gameEnd = false;
    }


    public void Win()
    {
        bossActController.BossDead();
        Debug.Log("You Win!");
        gameEnd = true;
        win.Invoke();
        winLoseUIControl.ShowWinUI(bossActController.GetHitPlayerCount());
    }

    public void Lose()
    {
        Debug.Log("You Lose!");
        gameEnd = true;
        lose.Invoke();
        winLoseUIControl.ShowLoseUI();
    }


}
