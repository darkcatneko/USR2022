using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] goods;
    [SerializeField] private GameObject[] notGoods;
    [SerializeField] private GameObject[] Special;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject player;
    [SerializeField] public float minAngle;
    [SerializeField] private float maxAngle;
    [SerializeField] private ThrowGoodsBossController throwGoodsBossController;
    private int count = 0;
    [SerializeField] private float specialAngle = 60f;
    private float inputAngle;
    private float distanceToPlayer;
    private float heightAdjust = 1f;
    private float gravity = -9.8f;


    

    public void spawnGoods()
    {
        int goodsIndex = Random.Range(0, goods.Length);
        int notGoodsIndex = Random.Range(0, goods.Length);
        GameObject good = Instantiate(goods[goodsIndex], spawnPoint.transform.position, Quaternion.identity);
        distanceToPlayer = spawnPoint.transform.position.z - player.transform.position.z;

        if (count < 5)
        { 
            count++;
            inputAngle = Random.Range(minAngle, maxAngle);

        }
        else
        {
            count = 0;
            inputAngle = specialAngle;
           
           
        }

        throwGoodsBossController.nextThrowTime = distanceToPlayer / (Mathf.Cos(Mathf.Deg2Rad * inputAngle)* Speed(inputAngle)) - distanceToPlayer / (Mathf.Cos(Mathf.Deg2Rad * minAngle) * Speed(minAngle));

        good.GetComponent<GoodsMovement>().StartMove(inputAngle, Speed(inputAngle), gravity);
    }

    private float Speed(float _angle)
    {
        float speed = Mathf.Sqrt(-gravity * distanceToPlayer * distanceToPlayer / (2 * Mathf.Cos(Mathf.Deg2Rad * _angle) * Mathf.Cos(Mathf.Deg2Rad * _angle) * (distanceToPlayer * Mathf.Tan(Mathf.Deg2Rad * _angle) - heightAdjust)));
        return speed;
    }







}
