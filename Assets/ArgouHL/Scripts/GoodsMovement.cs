using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsMovement : MonoBehaviour
{
    private GameObject player;
    private GameObject boss;
    private Vector3 orgPos;
    private float distanceToPlayer;
    private float speed;
    private float heightAdjust = 0.5f;
    private float gravity = -9.8f;
    private float angle;

    public void StartMove(float _angle)
    {
        angle = _angle;
        player = GameObject.FindGameObjectWithTag("Player");
        boss =  GameObject.FindGameObjectWithTag("Boss");
        distanceToPlayer = transform.position.z - player.transform.position.z;
        
        orgPos = transform.position;
        
        speed = Mathf.Sqrt(-gravity * distanceToPlayer * distanceToPlayer / (2 * Mathf.Cos(Mathf.Deg2Rad * angle) * Mathf.Cos(Mathf.Deg2Rad * angle) * (distanceToPlayer * Mathf.Tan(Mathf.Deg2Rad * angle) - heightAdjust)));

        boss.GetComponent<ThrowGoodsBossController>().nextThrowTime = boss.GetComponent<ThrowGoodsBossController>().minNextThrowTime+distanceToPlayer /(Mathf.Cos(Mathf.Deg2Rad * angle) * speed)-distanceToPlayer/(Mathf.Cos(Mathf.Deg2Rad *boss.GetComponent<GoodSpawn>().minAngle) * speed);
        StartCoroutine("Throwed");

    }

    private IEnumerator Throwed()
    {
        yield return new WaitForSeconds(11f * 1f / 60f);
        float time = 0;
        float duration = 4f*1f/60f;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(orgPos, new Vector3(orgPos.x, orgPos.y+0.3f, orgPos.z-0.3f), time / duration);

            time += Time.deltaTime;
            yield return null;
        }



        orgPos = transform.position;
        
        


        time = 0;
        while (transform.position.y>=0)
        {
            time += Time.deltaTime;
            float newPosZ = orgPos.z - Mathf.Cos(Mathf.Deg2Rad * angle) * speed * time;
            float newPosY = orgPos.y + Mathf.Sin(Mathf.Deg2Rad * angle) * speed * time+  0.5f*gravity*time*time;

            transform.position = new Vector3(orgPos.x, newPosY, newPosZ);
            
            yield return null;
        }

        Destroy(this.gameObject);
        StopCoroutine("Throwed");
    }



}
