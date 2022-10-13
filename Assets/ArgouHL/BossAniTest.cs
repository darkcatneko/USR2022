using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAniTest : MonoBehaviour
{
    [SerializeField] Animator bossAni;
    private void Start()
    {
        StartCoroutine(move());
    }


    IEnumerator move()
    {
        yield return new WaitForSeconds(2);
        
        float time = 0;
        bossAni.SetTrigger("goAtk");
        yield return new WaitForSeconds(0.75f);
        while (time<0.25f)
        {
            transform.position = new Vector3(0,0,Mathf.Lerp(0,-3,time/ 0.25f));

            time += Time.deltaTime;
            yield return null;
        }
        transform.position = new Vector3(0, 0, -3);

       
        time = 0;
        bossAni.SetTrigger("goBack");
        while (time < 1f)
        {
            transform.position = new Vector3(0, 0, Mathf.Lerp(-3, 0, time / 1f));

            time += Time.deltaTime;
            yield return null;
        }
        transform.position = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(1);
        StartCoroutine(move());
    }

}
