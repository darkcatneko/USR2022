using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    public static bool gameIsPause = false;

    [SerializeField] private GameObject tutorialMenuUI;

    [SerializeField] private List<GameObject> pages;
    private int currentPage;

    public void TutorialButton()
    {
        Pause();
        currentPage = 0;
        foreach(GameObject page in pages)
        {
            page.SetActive(false);
        }
        pages[currentPage].SetActive(true);
    }

    public void Resume()
    {
        tutorialMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
    }

    private void Pause()
    {
        tutorialMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
    }

    public void NextImage()
    {
        pages[currentPage].SetActive(false);
        currentPage++;
        pages[currentPage].SetActive(true);
    }

    public void PreviousImage()
    {
        pages[currentPage].SetActive(false);
        currentPage--;
        pages[currentPage].SetActive(true);
    }
}
