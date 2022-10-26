using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsMovement : MonoBehaviour
{
    private GameObject player;
    private GameObject boss;
    private Vector3 orgPos;
    
    private float speed;
    
    private float gravity;
    private float angle;
    
   [SerializeField] private float _animotionSpeed;

    public void Start()
    {
        
    }



    public void StartMove(float _angle, float _speed, float _gravity)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("Boss");
        _animotionSpeed = boss.GetComponent<ThrowGoodsBossController>().animatorSpeed;

        angle = _angle;
        speed = _speed;
        gravity = _gravity;
        
        
        orgPos = transform.position;
        
        StartCoroutine("Throwed");

    }

    private IEnumerator Throwed()
    {
        

        yield return new WaitForSeconds(20f * 1f / 24f / _animotionSpeed);
        
        float time = 0;

        
        orgPos = transform.position;
        
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
