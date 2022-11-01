using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceWinner : MonoBehaviour
{
    public result[] Results = new result[4];

    public void WhoIsTheWinner()
    {
        ResultEnum Biggest = ResultEnum.Normal;
        int BiggestNum = 0;
        int BiggestWho = 0;
        for (int i = 0; i < Results.Length; i++)
        {
            if (Results[i].resultEnum == ResultEnum.FourSame)
            {
                Biggest = ResultEnum.FourSame;
            }
        }
        if (Biggest == ResultEnum.FourSame)
        {
            for (int i = 0; i < Results.Length; i++)
            {
                if (Results[i].resultEnum == ResultEnum.FourSame&& Results[i].PointGet>BiggestNum)
                {
                    BiggestNum = Results[i].PointGet;
                    BiggestWho = i;
                }
            }
        }
        else
        {
            for (int i = 0; i < Results.Length; i++)
            {
                if (Results[i].resultEnum == ResultEnum.Normal && Results[i].PointGet > BiggestNum)
                {
                    BiggestNum = Results[i].PointGet;
                    BiggestWho = i;
                }
            }
        }
    }
}
