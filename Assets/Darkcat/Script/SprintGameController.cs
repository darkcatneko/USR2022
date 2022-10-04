using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SprintGameController : MonoBehaviour
{
    public static SprintGameController instance; 

    public float PlayerHealth = 150f;

    public Image PlayerHealthBar; public Image Marker; public GameObject MarkerEnd;
    private Vector3 MarkerStart;
    public GenAndCtrl LevelSystem;
    private void Start()
    {
        MarkerStart = Marker.transform.position;
    }
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        TimerUpdate();
        PlayerHealthBar.fillAmount = PlayerHealth/150f;
        PointerMovement(LevelSystem.LvProgress);
    }
    public void MinusHealth()
    {
        PlayerHealthBar.transform.DOShakePosition(0.13f,15);
        DOTween.To(() => PlayerHealth, x => PlayerHealth = x, PlayerHealth - 10f, 0.3f);
        if (PlayerHealth-10f==0)
        {
            Debug.Log("YouLose");//等日後新增輸掉事件
        }
    }
    public void TimerUpdate()
    {
        PlayerHealth -= Time.deltaTime;
        if (PlayerHealth <= 0)
        {
            Debug.Log("YouLose");//等日後新增輸掉事件
        }
    }
    public void Minustime()
    {
        PlayerHealth -= 10f;
    }
    public void PointerMovement(float LevelProgress)
    {
        
        Marker.transform.position = (MarkerEnd.transform.position - MarkerStart) * (LevelProgress / 150f) + MarkerStart;
    }
    
}
