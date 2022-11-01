using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceThrower : MonoBehaviour
{
    public Vector3[] DicesMoto = new Vector3[4];
    public Transform[] Dices = new Transform[4];
    public Transform BowlPoint;
    public float strength = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ThrowDice()
    {
        for (int i = 0; i < Dices.Length; i++)
        {
            DicesMoto[i] = Dices[i].position;
            Dices[i].GetComponent<Rigidbody>().useGravity = true;
            Dices[i].Rotate(new Vector3(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180)));
            Dices[i].GetComponent<Rigidbody>().AddForce((BowlPoint.transform.position - Dices[i].position)* strength, ForceMode.Impulse);
        }
    }
}
