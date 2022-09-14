using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnTest : MonoBehaviour
{
    [SerializeField] private GameObject[] goods;

    public void spawnCube()
    {
         
            int index = Random.Range(0, goods.Length);
            
            Instantiate(goods[index], transform.position, Quaternion.identity);

    }


}
