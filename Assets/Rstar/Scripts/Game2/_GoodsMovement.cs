using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _GoodsMovement : MonoBehaviour
{
    private GameObject player;
    private GameObject boss;
    private Vector3 orgPos;
    
    private float speed;
    
    private float gravity;
    private float angle;

    public void StartMove(float _angle, float _speed, float _gravity)
    {
        angle = _angle;
        speed = _speed;
        gravity = _gravity;
        player = GameObject.FindGameObjectWithTag("Player");
        boss =  GameObject.FindGameObjectWithTag("Boss");
        
        orgPos = transform.position;
        
        StartCoroutine("Throwed");

    }

    private IEnumerator Throwed()
    {
        yield return new WaitForSeconds(11f * 1f / 60f);
        float time = 0;
        float duration = 4f*1f/60f;
        //while (time < duration)
        //{
        //    transform.position = Vector3.Lerp(orgPos, new Vector3(orgPos.x, orgPos.y+0.3f, orgPos.z-0.3f), time / duration);

        //    time += Time.deltaTime;
        //    yield return null;
        //}



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

    public void Catched()
    {
        Destroy(this.gameObject.GetComponent<_GoodsMovement>());
        StopCoroutine("Throwed");
    }
}
