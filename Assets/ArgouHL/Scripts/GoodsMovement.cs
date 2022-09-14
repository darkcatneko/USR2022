using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 orgPos;
    private float distanceToPlayer;
    private float speed;
    private float angle;
    private float heightAdjust = 0.7f;
    private float gravity = -9.8f;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        distanceToPlayer =  transform.position.z- player.transform.position.z;
        orgPos = transform.position;
        angle = Random.Range(5f, 45f);
        speed = Mathf.Sqrt(-gravity*distanceToPlayer*distanceToPlayer/(2*Mathf.Cos(Mathf.Deg2Rad*angle) * Mathf.Cos(Mathf.Deg2Rad * angle)*(distanceToPlayer*Mathf.Tan(Mathf.Deg2Rad * angle)-heightAdjust)));
        print(speed);
        StartMove();

    }

    private void StartMove()
    {
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
        angle = Random.Range(25f, 60f);
        speed = Mathf.Sqrt(-gravity * distanceToPlayer * distanceToPlayer / (2 * Mathf.Cos(Mathf.Deg2Rad * angle) * Mathf.Cos(Mathf.Deg2Rad * angle) * (distanceToPlayer * Mathf.Tan(Mathf.Deg2Rad * angle) - heightAdjust)));
        


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
