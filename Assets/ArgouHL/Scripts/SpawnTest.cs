using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnTest : MonoBehaviour
{
    [SerializeField] private GameObject[] goods;
    private float[] angles = { 0, 5, 15, 20, 25, 30,60 };
    float specialAbgle = 60f;

    public void spawnCube()
    {
        float inputAngle = angles[Random.Range(0, angles.Length-1)];
        int index = Random.Range(0, goods.Length);
            
        GameObject good=Instantiate(goods[index], transform.position, Quaternion.identity);
        good.GetComponent<GoodsMovement>().StartMove(inputAngle);

    }


}
