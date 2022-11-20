using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EntryUI : MonoBehaviour
{
    [SerializeField] private Button gameStartBtn;
    [SerializeField] private CanvasGroup gameStartUI;
    [SerializeField] private CanvasGroup gameStartText;
    [SerializeField] private UnityEvent gameStart;
    private void Start()
    {
        gameStartBtn.interactable = false;
        StartCoroutine("InFade");
        
       
        Invoke("CanStart", 5);
    }

    public void GameStart()
    {
        gameStartBtn.interactable = false;
        StartCoroutine("StartFade");
        

    }

    
    private void CanStart()
    {
        gameStartBtn.interactable = true;
    }

    private IEnumerator StartFade()
    {
            
        float time = 0;
        float duration = 1.5f;
        while(time<duration)
        {
            gameStartUI.alpha = Mathf.Lerp(1, 0, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        gameStartUI.alpha = 0;
        gameStartUI.interactable = false;
        gameStartUI.blocksRaycasts = false;
        gameStart.Invoke();
    }

    private IEnumerator InFade()
    {
        yield return new WaitForSeconds(1);
        float time = 0;
        float duration = 2;
        while (time < duration)
        {
            gameStartText.alpha = Mathf.Lerp(0, 1, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

    }


}
