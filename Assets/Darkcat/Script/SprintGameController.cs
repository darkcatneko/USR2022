using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SprintGameController : MonoBehaviour
{
    public static SprintGameController instance; 

    public float PlayerHealth = 150f;

    public Slider PlayerHealthBar; public Image Marker; public GameObject MarkerEnd;

    [SerializeField] GenAndCtrl LevelSystem;
    private void Update()
    {
        TimerUpdate();
        PlayerHealthBar.value = PlayerHealth/150f; 
        //PointerMovement(LevelSystem.)
    }
    public void MinusHealth()
    {
        PlayerHealthBar.transform.DOShakePosition(0.3f,30);
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
        Marker.transform.position = (MarkerEnd.transform.position - Marker.transform.position) * (LevelProgress / 150f) + Marker.transform.position;
    }
}
