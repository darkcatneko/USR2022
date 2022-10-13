using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.UI;

public class ThrowGoodsBossController : MonoBehaviour
{
    [SerializeField] private Animator bossAnimator;
    [SerializeField] private UnityEvent throwGoodsEvents;
    private float randomMaxThrowTimeOffset;
    [SerializeField] private Slider timeBar;
    [SerializeField] private float gameTime;
    [SerializeField] private GoodSpawn goodSpawn;
    [Header("Stage 1")]

    [SerializeField] private float stage1MinNextThrowTime;
    [SerializeField] private float stage1MaxNextThrowTime;
    [SerializeField] private float timeToStage2;
    [SerializeField] private float stage1HighPercentage;
    [Header("Stage 2")]
    [SerializeField] private float stage2MinNextThrowTime;
    [SerializeField] private float stage2MaxNextThrowTime;
    [SerializeField] private float timeToStage3;
    [SerializeField] private float stage2HighPercentage;

    [Header("Stage 1")]
    [SerializeField] private float stage3MinNextThrowTime;
    [SerializeField] private float stage3MaxNextThrowTime;
    [SerializeField] private float stage3HighPercentage;
        



    [SerializeField] private bool gamestart;
    public float nextThrowTime;
    private float minNextThrowTime;
    private float maxNextimeOffset;

    private void Start()
    {
        timeBar.maxValue = gameTime;
        timeBar.value = gameTime;
        minNextThrowTime = stage1MinNextThrowTime;
        maxNextimeOffset = stage1MaxNextThrowTime;
        nextThrowTime = stage1MinNextThrowTime;
        goodSpawn.highAnglePercentage = stage1HighPercentage;
        StartCoroutine("ThrowGoodsLoop");
        StartCoroutine("GameStart");
    }

    

    private IEnumerator GameStart()
    {
        while (gameTime> timeToStage2)
        {
            gameTime-=Time.deltaTime;
            yield return null;
            timeBar.value = gameTime;
        }
        
        minNextThrowTime = stage2MinNextThrowTime;
        maxNextimeOffset = stage2MaxNextThrowTime;
        goodSpawn.highAnglePercentage = stage2HighPercentage;

        while (gameTime > timeToStage3)
        {
            gameTime -= Time.deltaTime;
            yield return null;
            timeBar.value = gameTime;
        }

        minNextThrowTime = stage3MinNextThrowTime;
        maxNextimeOffset = stage3MaxNextThrowTime;
        goodSpawn.highAnglePercentage = stage3HighPercentage;

        while (gameTime >0)
        {
            gameTime -= Time.deltaTime;
            yield return null;
            timeBar.value = gameTime;
        }

        StopCoroutine("ThrowGoodsLoop");
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
            
            yield return new WaitForSeconds(nextThrowTime);
            ThrowGoods();
            yield return new WaitForSeconds(Random.Range(minNextThrowTime, maxNextimeOffset));
            
        }
    }





}
