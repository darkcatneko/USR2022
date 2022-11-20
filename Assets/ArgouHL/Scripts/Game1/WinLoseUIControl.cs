using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinLoseUIControl : MonoBehaviour
{
    [SerializeField] private CanvasGroup winUI;
    [SerializeField] private CanvasGroup loseUI;
    [SerializeField] private TMP_Text failCountText;

    public void ShowWinUI(int failCount)
    {
        failCountText.text = failCount.ToString();
        
        StartCoroutine("WinUIFade");
    }

    private IEnumerator WinUIFade( )
    {
        float time = 0;
        float duration = 2;
        while ( time<duration)
        {
            winUI.alpha = Mathf.Lerp(0, 1, time / duration);
            time += Time.deltaTime;
            yield return null; 
        }
        winUI.alpha = 1;
        winUI.blocksRaycasts = true;
        winUI.interactable = true;
    }

    public void ShowLoseUI()
    {
       
        
        StartCoroutine("LoseUIFade");
    }

    private IEnumerator LoseUIFade()
    {
       
       float time = 0;
        float duration = 2;
        while (time < duration)
        {
            loseUI.alpha = Mathf.Lerp(0, 1, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        loseUI.alpha = 1;
        loseUI.blocksRaycasts = true;
        loseUI.interactable = true;
    }


    public void BackHome()
    {
        SceneManager.LoadScene(0);
        print("BackHome");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("replay");
    }
}
