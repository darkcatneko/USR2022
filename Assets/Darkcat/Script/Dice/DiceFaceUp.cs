using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiceFaceUp : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    public bool StartGame = false;
    public bool CanRead = false;
    public Transform[] Sides = new Transform[6];
    public DiceEnum DR;
    Coroutine WaitSelfStopIE;

    [SerializeField] UnityEvent Stop;

    IEnumerator WaitSelfStop()
    {
        while(!CanRead)
        {
            yield return new WaitForFixedUpdate();
        }
        DR = CheckUpSide();
        Stop.Invoke();
        WaitSelfStopIE = null;
    }

    public void StartWaitSelfStop()
    {
        if(WaitSelfStopIE == null)
        {
            WaitSelfStopIE = StartCoroutine("WaitSelfStop");
        }
    }

    void Start()
    {
        m_rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (m_rigidbody.velocity.magnitude > 0.0005f && StartGame == false)
        {
            StartGame = true;
            CanRead = false;
        }
        if (m_rigidbody.velocity.magnitude < 0.0005f && StartGame == true)
        {
            StartGame = false;
            CanRead = true;
        }
    }
    public DiceEnum CheckUpSide()
    {
        int LowestNum = 0;
        float Lowest = Sides[0].position.y;
        for (int i = 0; i < Sides.Length; i++)
        {
            if (Sides[i].position.y <= Lowest)
            {
                Lowest = Sides[i].position.y;
                LowestNum = i;
            }
        }
        switch (LowestNum)
        {
            case 0:
                return DiceEnum.Six;
            case 1:
                return DiceEnum.Five;
            case 2:
                return DiceEnum.Four;
            case 3:
                return DiceEnum.Three;
            case 4:
                return DiceEnum.Two;
            case 5:
                return DiceEnum.One;
        }
        return DiceEnum.One;
    }
    
}
