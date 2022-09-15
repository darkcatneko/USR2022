using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] goods;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] public float minAngle;
    [SerializeField] private float maxAngle;
    [SerializeField] private ThrowGoodsBossController throwGoodsBossController;
    private int count = 0;
    [SerializeField] private float specialAngle = 60f;
    private float inputAngle;

    public void spawnCube()
    {
        int index = Random.Range(0, goods.Length);
        GameObject good = Instantiate(goods[index], spawnPoint.transform.position, Quaternion.identity);

        if (count < 6)
        { 
            count++;
            float inputAngle = Random.Range(minAngle, maxAngle);
            good.GetComponent<GoodsMovement>().StartMove(inputAngle);
        }
        else
        {
            count = 0;
            inputAngle = specialAngle;
            good.GetComponent<GoodsMovement>().StartMove(inputAngle);
           
        }
        






    }


}
