using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinLoseUIControlGame2 : MonoBehaviour
{
    [SerializeField] private CanvasGroup winUI;
    [SerializeField] private CanvasGroup loseUI;
    [SerializeField] private TMP_Text CoinCountText;
    [SerializeField] private TMP_Text TotalCoinCountText;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private GameDataCtr gameDataCtr;

    public void ShowWinUI()
    {
        CoinCountText.text = gameDataCtr.playerMoney.ToString();
        TotalCoinCountText.text = playerData.ThisPlayer.Player_Money.ToString();
        winUI.blocksRaycasts = true;
        winUI.interactable = true;
        StartCoroutine("WinUIFade");
    }

    private IEnumerator WinUIFade()
    {
        float time = 0;
        float duration = 2;
        while (time < duration)
        {
            winUI.alpha = Mathf.Lerp(0, 1, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        winUI.alpha = 1;
    }

    public void ShowLoseUI()
    {

        loseUI.blocksRaycasts = true;
        loseUI.interactable = true;
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
