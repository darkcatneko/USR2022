using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceResult : MonoBehaviour
{

    public DiceFaceUp[] diceFaceUps = new DiceFaceUp[4];
    public void Test()
    {
        Debug.Log(ReadTheResult().resultEnum.ToString()+"   "+ ReadTheResult().PointGet.ToString());
    }
    public result ReadTheResult()
    {
        int[] resultCab = new int[6];
        ResultEnum RE;
        int Combine = 0;
        int Biggest = 0;
        int FourNotSame = 0;
        for (int i = 0; i < diceFaceUps.Length; i++)
        {
            if (diceFaceUps[i].CanRead == false)
            {
                return null;
            }
        }//確認四顆都靜止
        for (int i = 0; i < diceFaceUps.Length; i++)//統計結果
        {
            resultCab[(int)diceFaceUps[i].DR]++;
        }        
        for (int i = 0; i < resultCab.Length; i++)
        {
            if (resultCab[i]==4)
            {
                return new result(ResultEnum.FourSame, i);
            }
            if (resultCab[i] == 3)
            {
                return new result(ResultEnum.NeedToReThrow, i);
            }
            if (resultCab[i] == 2)
            {
                Combine++;
                Biggest = i;
            }
            if (resultCab[i]==1)
            {
                FourNotSame++;
            }
        }
        if (FourNotSame ==4)
        {
            return new result(ResultEnum.NeedToReThrow, 0);
        }
        if (Combine == 1)
        {
            int Score = 0;
            for (int i = 0; i < resultCab.Length; i++)
            {
                if (resultCab[i]==1)
                {
                    Score += i+1;
                }
            }
            return new result(ResultEnum.Normal, Score);
        }
        if (Combine == 2)
        {
            return new result(ResultEnum.Normal,(Biggest+1)*2 );
        }
        return new result(ResultEnum.NeedToReThrow, 0);
    }
}



public class result
{
    public ResultEnum resultEnum;
    public int PointGet;
    public result(ResultEnum re, int pt)
    {
        resultEnum = re;
        PointGet = pt;
    }
}
public enum ResultEnum
{
    NeedToReThrow,
    FourSame,
    Normal,
}

