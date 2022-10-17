using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodSpawn : MonoBehaviour
{
    
    [SerializeField] private GameObject[] goods_1;
    [SerializeField] private GameObject[] goods_2;
    [SerializeField] private GameObject[] goods_3;
    private GameObject[][] goods;
    [SerializeField] private GameObject[] notGoods;
    //[SerializeField] private GameObject[] Special;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject player;
    [SerializeField] public float minAngle;
    [SerializeField] private float maxAngle;
    [SerializeField] private ThrowGoodsBossController throwGoodsBossController;
    public float highAnglePercentage;
    public float wrongGoodPercentage;
    [SerializeField] private float specialAngle = 60f;
    [SerializeField] private GameObject currentGood;
    private float inputAngle;
    private float distanceToPlayer;
    private float heightAdjust = 1f;
    private float gravity = -9.8f;
    private bool isHighGoodThrowed = true;
    private bool isCurrentNotGood = true;
    private int lastgoodsIndex = 0;
    private void Start()
    {
        goods = new GameObject[3][] { goods_1, goods_2, goods_3};
    }


    public void spawnGood()
    {
        
        print("spawnGood");
        distanceToPlayer = spawnPoint.transform.position.z - player.transform.position.z;
        if (isCurrentNotGood)
        {
            int goodsIndex = Random.Range(0, goods.Length);
            while(lastgoodsIndex == goodsIndex)
            {
                goodsIndex = Random.Range(0, goods.Length);
            }
            lastgoodsIndex = goodsIndex;

            currentGood = Instantiate(goods[goodsIndex][Random.Range(0, goods[goodsIndex].Length)], spawnPoint.transform.position, Quaternion.identity);

            isCurrentNotGood = false;
        }
        else
        {
            if (Random.Range(0f, 1f) > wrongGoodPercentage ? true : false)
            {
                int goodsIndex = Random.Range(0, goods.Length);
                while (lastgoodsIndex == goodsIndex)
                {
                    goodsIndex = Random.Range(0, goods.Length);
                }
                lastgoodsIndex = goodsIndex;
                currentGood = Instantiate(goods[goodsIndex][Random.Range(0, goods[goodsIndex].Length)], spawnPoint.transform.position, Quaternion.identity);
                isCurrentNotGood = false;

            }
            else
            {
                int notGoodsIndex = Random.Range(0, notGoods.Length);
                currentGood = Instantiate(notGoods[notGoodsIndex], spawnPoint.transform.position, Quaternion.identity);
                isCurrentNotGood = true;
            }
        }


        if (!isHighGoodThrowed)
        {
            if (Random.Range(0f, 1f) > highAnglePercentage ? true : false)
            {

                inputAngle = Random.Range(minAngle, maxAngle);

            }
            else
            {

                inputAngle = specialAngle;
                isHighGoodThrowed = true;


            }
        }
        else
        {
            inputAngle = Random.Range(minAngle, maxAngle);
        }


        throwGoodsBossController.nextThrowTime = distanceToPlayer / (Mathf.Cos(Mathf.Deg2Rad * inputAngle) * Speed(inputAngle)) - distanceToPlayer / (Mathf.Cos(Mathf.Deg2Rad * minAngle) * Speed(minAngle));
        print("s" + throwGoodsBossController.nextThrowTime);

    }


    public void throwGood()
    {
        
        currentGood.AddComponent<GoodsMovement>().StartMove(inputAngle, Speed(inputAngle), gravity);
        
    }


    private float Speed(float _angle)
    {
        float speed = Mathf.Sqrt(-gravity * distanceToPlayer * distanceToPlayer / (2 * Mathf.Cos(Mathf.Deg2Rad * _angle) * Mathf.Cos(Mathf.Deg2Rad * _angle) * (distanceToPlayer * Mathf.Tan(Mathf.Deg2Rad * _angle) - heightAdjust)));
        return speed;
    }

    





}
