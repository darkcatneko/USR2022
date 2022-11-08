using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.UI;

public class ThrowGoodsBossController : MonoBehaviour
{
    [SerializeField] private GameDataCtr gameDataCtr;
    [SerializeField] public Animator bossAnimator;
    [SerializeField] private UnityEvent throwGoodsEvents;
    [SerializeField] public UnityEvent spawnGoodsEvents;
    [SerializeField] public UnityEvent gameEnd;

    [SerializeField] private Slider timeBar;
    [SerializeField] private float gameTime;
    [SerializeField] private GoodSpawn goodSpawn;
    [Header("Stage 1")]

    [SerializeField] private float stage1MinNextThrowTime;
    [SerializeField] private float stage1MaxNextThrowTime;
    [SerializeField] private float timeToStage2;
    [SerializeField] private float stage1HighPercentage;
    [SerializeField] private float stage1WrongGoodPercentage;
    [Header("Stage 2")]
    [SerializeField] private float stage2MinNextThrowTime;
    [SerializeField] private float stage2MaxNextThrowTime;
    [SerializeField] private float timeToStage3;
    [SerializeField] private float stage2HighPercentage;
    [SerializeField] private float stage2WrongGoodPercentage;

    [Header("Stage 1")]
    [SerializeField] private float stage3MinNextThrowTime;
    [SerializeField] private float stage3MaxNextThrowTime;
    [SerializeField] private float stage3HighPercentage;
    [SerializeField] private float stage3WrongGoodPercentage;

    [SerializeField] private bool gamestart;
    public float nextThrowTime;
    private float minNextThrowTime;
    private float maxNextimeOffset;

    public float animatorSpeed=1f;

    private void Start()
    {
        timeBar.maxValue = gameTime;
        timeBar.value = gameTime;
        minNextThrowTime = stage1MinNextThrowTime;
        maxNextimeOffset = stage1MaxNextThrowTime;
        nextThrowTime = stage1MinNextThrowTime;
        goodSpawn.highAnglePercentage = stage1HighPercentage;
        goodSpawn.wrongGoodPercentage = stage1WrongGoodPercentage;
        animatorSpeed = 1f;
        
     

    }

    public void GameStart()
    {
        StartCoroutine("GameStartIEnumerator");
    }



    private IEnumerator GameStartIEnumerator()
    {
        StartCoroutine("ThrowGoodsLoop");
        while (gameTime > timeToStage2)
        {
            gameTime-=Time.deltaTime;
            yield return null;
            timeBar.value = gameTime;
        }
        print("toStage2");
        minNextThrowTime = stage2MinNextThrowTime;
        maxNextimeOffset = stage2MaxNextThrowTime;
        goodSpawn.highAnglePercentage = stage2HighPercentage;
        goodSpawn.wrongGoodPercentage = stage2WrongGoodPercentage;
        animatorSpeed = 1.5f;
        bossAnimator.speed = animatorSpeed;
        while (gameTime > timeToStage3)
        {
            gameTime -= Time.deltaTime;
            yield return null;
            timeBar.value = gameTime;
        }
        print("toStage3");
        minNextThrowTime = stage3MinNextThrowTime;
        maxNextimeOffset = stage3MaxNextThrowTime;
        goodSpawn.highAnglePercentage = stage3HighPercentage;
        goodSpawn.wrongGoodPercentage = stage3WrongGoodPercentage;
        animatorSpeed = 2f;
        bossAnimator.speed = animatorSpeed;
        while (gameTime >0)
        {
            gameTime -= Time.deltaTime;
            yield return null;
            timeBar.value = gameTime;
        }

        StopCoroutine("ThrowGoodsLoop");
        GameEnd();
    }





    private void ThrowGoods()
    {
    bossAnimator.SetTrigger("throw");
    throwGoodsEvents.Invoke();
    }


    private IEnumerator ThrowGoodsLoop()
    {
        while (true)
        {
           
            yield return new WaitForSeconds(Random.Range(minNextThrowTime, maxNextimeOffset));
            spawnGoodsEvents.Invoke();
            ThrowGoods();
            yield return new WaitForSeconds(nextThrowTime);
            
        }
    }

    private void GameEnd()
    {
       
        gamestart = false;
        gameDataCtr.Save();
        gameEnd.Invoke();
        Debug.Log("Time's Up");

    }



}
