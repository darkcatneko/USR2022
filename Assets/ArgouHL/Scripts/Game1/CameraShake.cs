using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 cameraOrgPos;
    [SerializeField] private float duration;
    [SerializeField] private float vibration;
    public void shake()
    {
        cameraOrgPos = Camera.main.transform.localPosition;
        StartCoroutine(Shaking(duration, vibration));


    }

    private  IEnumerator Shaking(float _duration, float _vibration)
    {
        float time = _duration;
        while(time > 0 )
        {
            float currentVibration = Mathf.Lerp(0, _vibration, time/_duration);
            Camera.main.transform.localPosition = cameraOrgPos + RandomShake(currentVibration);
            time -= Time.deltaTime;
             yield return null; 
        }
        Camera.main.transform.localPosition = cameraOrgPos;

    }

    private Vector3 RandomShake(float inputibration)
    {
        float x = Random.Range(-inputibration, inputibration);
        float y = Random.Range(-inputibration, inputibration);
        
        return new Vector3 (x,y,0);
    }
}
